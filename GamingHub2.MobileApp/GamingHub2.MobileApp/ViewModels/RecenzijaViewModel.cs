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
    public class RecenzijaViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Recenzija");

        public RecenzijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Recenzija> RecenzijaList { get; set; } = new ObservableCollection<Recenzija>();



        string _searchnaslov = null;
        public string Naslov
        {
            get { return _searchnaslov; }
            set { SetProperty(ref _searchnaslov, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        //Konzola _selectedKonzola = null;
        //public Konzola SelectedKonzola
        //{
        //    get { return _selectedKonzola; }
        //    set
        //    {
        //        SetProperty(ref _selectedKonzola, value);
        //        if (value != null)
        //        {
        //            InitCommand.Execute(null);
        //        }
        //    }
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _service.Get<IEnumerable<Recenzija>>(null);
            //RecenzijaList.Clear();
            //foreach (var recenzija in list)
            //{
            //    RecenzijaList.Add(recenzija);
            //}

            if (Naslov == null)
            {
                RecenzijaList.Clear();
                foreach (var recenzija in list)
                {
                    RecenzijaList.Add(recenzija);
                }
            }
            else
            {
                RecenzijaSearchRequest search = new RecenzijaSearchRequest();
                search.Naslov = _searchnaslov;

                list = await _service.Get<IEnumerable<Recenzija>>(search);
                RecenzijaList.Clear();
                foreach (var recenzija in list)
                {
                    RecenzijaList.Add(recenzija);
                }
            }

        }
        void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            RecenzijaSearchRequest search = new RecenzijaSearchRequest();
            search.Naslov = _searchnaslov;

            //var keyword = searchBar.Text;
            //searchResults.ItemsSource =

            //searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        }
    }
}
