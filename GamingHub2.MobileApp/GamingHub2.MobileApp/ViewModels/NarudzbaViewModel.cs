using GamingHub2.MobileApp.Services;
using GamingHub2.MobileApp.ViewModels;
using GamingHub2.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    public class NarudzbaViewModel : BaseViewModel
    {

        private readonly APIService _serviceNarudzba = new APIService("Narudzba");

        public ObservableCollection<ProizvodDetaljiViewModel> ProizvodiList { get; set; } = new ObservableCollection<ProizvodDetaljiViewModel>();
        public ICommand RemoveStavkaCommand { get; set; }
        public ICommand PovecajKolicinuIOsvjeziCommand { get; set; }
        public ICommand UmanjiKolicinuIOsvjeziCommand { get; set; }
        public ICommand KupiCommand { get; set; }

        public NarudzbaViewModel()
        {
            RemoveStavkaCommand = new Command<ProizvodDetaljiViewModel>(this.RemoveStavka);
            PovecajKolicinuIOsvjeziCommand = new Command<ProizvodDetaljiViewModel>(this.PovecajKolicinuIOsvjezi);
            UmanjiKolicinuIOsvjeziCommand = new Command<ProizvodDetaljiViewModel>(this.UmanjiKolicinuIOsvjezi);
            KupiCommand = new Command(async () => await this.Kupi());
        }

        public void Init()
        {
            ProizvodiList.Clear();
            foreach (var item in CartService.Cart)
            {
                ProizvodiList.Add(item.Value);
            }

            UpdateUkupniIznos();
        }

        private void RemoveStavka(ProizvodDetaljiViewModel obj)
        {
            if (CartService.Cart.ContainsKey(obj.Proizvod.ID))
            {
                CartService.Cart.Remove(obj.Proizvod.ID);
            }

            foreach (var item in ProizvodiList)
            {
                if (item.Proizvod == obj.Proizvod)
                {
                    ProizvodiList.Remove(item);
                    break;
                }
            }

            UpdateUkupniIznos();
        }

        private void PovecajKolicinuIOsvjezi(ProizvodDetaljiViewModel obj)
        {
            obj.PovecajKolicinuCommand.Execute(null);
            UpdateUkupniIznos();
        }


        private void UmanjiKolicinuIOsvjezi(ProizvodDetaljiViewModel obj)
        {
            obj.UmanjiKolicinuCommand.Execute(null);
            UpdateUkupniIznos();
        }


        private async Task Kupi()
        {
            if (CartService.Cart.Count == 0)
            {
                await Shell.Current.DisplayAlert("Greška", "Košarica je prazna!", "OK");
                return;
            }

            var request = new Model.Requests.NarudzbaInsertRequest
            {
                Datum = DateTime.Now,
                Status = false,
                NarudzbaStavke = new List<Model.Requests.NarudzbaStavkaInsertRequest>()
            };
            foreach (var stavka in CartService.Cart.Values)
            {
                request.NarudzbaStavke.Add(new Model.Requests.NarudzbaStavkaInsertRequest
                {
                    Cijena = stavka.Proizvod.ProdajnaCijena,
                    Popust = stavka.Proizvod.Popust,
                    Kolicina = stavka.Kolicina,
                    ProizvodId = stavka.Proizvod.ID
                });
            }

            var narudzba = await _serviceNarudzba.Insert<Model.Narudzba>(request);
            if (narudzba != null)
            {
                await Shell.Current.GoToAsync($"{nameof(StripePaymentGatewayPage)}?{nameof(PaymentGatewayPageViewModel.NarudzbaId)}={narudzba.NarudzbaId}");

            }

        }

        private void UpdateUkupniIznos()
        {
            decimal sum = 0;
            foreach (var item in CartService.Cart.Values)
            {
                sum += item.Kolicina * item.Proizvod.ProdajnaCijena * (1 - item.Proizvod.Popust / 100);
            }

            UkupniIznos = sum;
        }

        private decimal _ukupniIznos;

        public decimal UkupniIznos
        {
            get { return _ukupniIznos; }
            set { SetProperty(ref _ukupniIznos, value); }
        }

    }
}
