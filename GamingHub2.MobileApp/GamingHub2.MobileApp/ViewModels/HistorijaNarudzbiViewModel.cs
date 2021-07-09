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
    public class HistorijaNarudzbiViewModel
    {
        private readonly APIService _service = new APIService("Narudzba");

        public HistorijaNarudzbiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Narudzba> NarudzbaList { get; set; } = new ObservableCollection<Narudzba>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            //RecenzijaSearchRequest search = new RecenzijaSearchRequest
            //{
            //    Naslov = _searchnaslov
            //};

            var lista = await _service.Get<IEnumerable<Narudzba>>(null);
            NarudzbaList.Clear();
            foreach (var narudzba in lista)
            {
                if (narudzba.KorisnikID == APIService.TrenutniKorisnik.KorisnikId)
                {
                    NarudzbaList.Add(narudzba);
                }
            }
        }
    }
}
