using GamingHub2.MobileApp.Services;
using GamingHub2.MobileApp.Views;
using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    [QueryProperty(nameof(ProizvodId), nameof(ProizvodId))]
    public class ProizvodDetaljiViewModel : BaseViewModel
    {
        private readonly APIService _serviceProizvod = new APIService("Proizvod");
        private readonly APIService _serviceRecommender = new APIService("Recommender");
        private readonly APIService _serviceOcjena = new APIService("Ocjena");
        private readonly APIService _serviceKupac = new APIService("Kupac");
        public ProizvodDetaljiViewModel()
        {
            PovecajKolicinuCommand = new Command(() => Kolicina += 1);
            UmanjiKolicinuCommand = new Command(() => Kolicina = Math.Max(1, Kolicina - 1));
            NaruciCommand = new Command(Naruci);
            UcitajProizvodCommand = new Command(async () => await UcitajProizvod());
            PrikaziProizvodCommand = new Command<object>(async (proizvod) => await PrikaziProizvod(proizvod));

            OcijeniSa1Command = new Command(async () => await Ocijeni(1));
            OcijeniSa2Command = new Command(async () => await Ocijeni(2));
            OcijeniSa3Command = new Command(async () => await Ocijeni(3));
            OcijeniSa4Command = new Command(async () => await Ocijeni(4));
            OcijeniSa5Command = new Command(async () => await Ocijeni(5));
        }

        public async Task Ocijeni(int ocjena)
        {
            var kupacList = await GetKupacByKorisnikid();
            if (kupacList == null || kupacList.Count == 0)
            {
                await Shell.Current.DisplayAlert("Greška", "Nije moguće ocijeniti proizvod.", "OK");
                return;
            }
            var kupacID = kupacList[0].ID;

            Model.Requests.OcjenaUpsertRequest request = new Model.Requests.OcjenaUpsertRequest
            {
                ProizvodId = Proizvod.ID,
                KupacId = kupacID,
                OcjenaProizvoda = ocjena,
                Datum = DateTime.Now
            };
            var searchRequest = new Model.Requests.OcjenaSearchRequest
            {
                KupacId = kupacID,
                ProizvodId = Proizvod.ID
            };
            var postojecaOcjena = await _serviceOcjena.Get<List<Model.Ocjena>>(searchRequest);


            Ocjena novaOcjena;
            if (postojecaOcjena != null && postojecaOcjena.Count > 0)
            {
                novaOcjena = await _serviceOcjena.Update<Model.Ocjena>(postojecaOcjena[0].OcjenaId, request);
            }
            else
            {
                novaOcjena = await _serviceOcjena.Insert<Model.Ocjena>(request);
            }

            if (novaOcjena != null)
            {
                await App.Current.MainPage.DisplayAlert("Uspješno ocijenjeno", "", "OK");
            }
        }

        private Proizvod _proizvod;

        public Proizvod Proizvod
        {
            get { return _proizvod; }
            set { if (_proizvod != value)
                {
                    SetProperty(ref _proizvod, value);
                    UpdateCijenaInfo();
                }
            }
        }

        int _kolicina = 1;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }
        private int _proizvodId;

        public int ProizvodId
        {
            get { return _proizvodId; }
            set
            {
                if (_proizvodId != value)
                {
                    SetProperty(ref _proizvodId, value);
                    UcitajProizvodCommand.Execute(null);
                }
            }
        }

        private bool _imaPopust;

        public bool ImaPopust
        {
            get { return _imaPopust; }
            set
            {
                SetProperty(ref _imaPopust, value);
            }
        }

        private TextDecorations _ProdajnaCijenaTextDecorations;

        public TextDecorations ProdajnaCijenaTextDecorations
        {
            get { return _ProdajnaCijenaTextDecorations; }
            set { SetProperty(ref _ProdajnaCijenaTextDecorations, value); }
        }


        public ICommand PovecajKolicinuCommand { get; set; }
        public ICommand UmanjiKolicinuCommand { get; set; }
        public ICommand NaruciCommand { get; set; }
        public ICommand UcitajProizvodCommand { get; set; }
        public ICommand PrikaziProizvodCommand { get; set; }

        public ICommand OcijeniSa1Command { get; set; }
        public ICommand OcijeniSa2Command { get; set; }
        public ICommand OcijeniSa3Command { get; set; }
        public ICommand OcijeniSa4Command { get; set; }
        public ICommand OcijeniSa5Command { get; set; }

        public ObservableCollection<Model.Proizvod> RecommenderList { get; set; } = new ObservableCollection<Proizvod>();

        public async Task Init()
        {
            if (Proizvod == null)
                return;

            RecommenderList.Clear();
            var list = await _serviceRecommender.GetById<List<Model.Proizvod>>(Proizvod.ID);
            foreach (var item in list)
            {
                RecommenderList.Add(item);
            }
        }

        public async Task UcitajProizvod()
        {
            Proizvod = await _serviceProizvod.GetById<Model.Proizvod>(ProizvodId);
            await Init();
        }

        private void UpdateCijenaInfo()
        {
            if (Proizvod.Popust > 0)
            {
                ProdajnaCijenaTextDecorations = TextDecorations.Strikethrough;
                ImaPopust = true;
            }
            else
            {
                ProdajnaCijenaTextDecorations = TextDecorations.None;
                ImaPopust = false;
            }
        }

        private async Task PrikaziProizvod(object proizvod)
        {
            if (proizvod is Proizvod p)
            {
                await Shell.Current.GoToAsync($"{nameof(ProizvodDetaljiPage)}?{nameof(ProizvodDetaljiViewModel.ProizvodId)}={p.ID}");
            }
        }


        private async void Naruci()
        {
            if (CartService.Cart.ContainsKey(Proizvod.ID))
            {
                CartService.Cart.Remove(Proizvod.ID);
            }
            CartService.Cart.Add(Proizvod.ID, this);

            await Shell.Current.DisplayAlert("", "Proizvod dodan u košaricu.", "OK");
        }

        private async Task<List<Kupac>> GetKupacByKorisnikid()
        {
            return await _serviceKupac.Get<List<Model.Kupac>>(new Model.Requests.KupacSearchRequest
            {
                KorisnikId = APIService.TrenutniKorisnik.KorisnikId
            });
        }


    }
}
