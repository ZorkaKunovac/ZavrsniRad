using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    public class ProizvodiViewModel :BaseViewModel
    {
        private readonly APIService _service = new APIService("Proizvod");
        private readonly APIService _konzolaService = new APIService("Konzola");

        public ProizvodiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Proizvod> ProizvodiList { get; set; } = new ObservableCollection<Proizvod>();
        public ObservableCollection<Konzola> KonzolaList { get; set; } = new ObservableCollection<Konzola>();

        Konzola _selectedKonzola = null;
        public Konzola SelectedKonzola
        {
            get { return _selectedKonzola; }
            set { SetProperty(ref _selectedKonzola, value); 
                if(value !=null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _service.Get<IEnumerable<Proizvod>>(null);

            if (SelectedKonzola == null)
            {
                ProizvodiList.Clear();
                foreach (var proizvod in list)
                {
                    ProizvodiList.Add(proizvod);
                }
            }
            else
            {
                // if(SelectedKonzola !=null)
                ProizvodSearchRequest search = new ProizvodSearchRequest();
                search.NazivKonzole = SelectedKonzola.Naziv;

                list = await _service.Get<IEnumerable<Proizvod>>(search);
                ProizvodiList.Clear();
                foreach (var proizvod in list)
                {
                    ProizvodiList.Add(proizvod);
                }
            }
            if (KonzolaList.Count == 0)
            {
                var konzolalist = await _konzolaService.Get<IEnumerable<Konzola>>(null);
                foreach (var konzola in konzolalist)
                {
                    KonzolaList.Add(konzola);
                }
            }

           
        }
    }
}
