using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    public class RecenzijaViewModel : BaseViewModel
    {
        APIService _service = new APIService("Recenzija");
        public ICommand InitCommand { get; set; }
        public Command PretragaCommand { get; }

        public RecenzijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
            PretragaCommand = new Command(async () => await Pretraga());
        }
       // public ObservableCollection<Recenzija> RecenzijaList { get; set; } = new ObservableCollection<Recenzija>();

        public ObservableCollection<Recenzija> recenzije { get; set; } = new ObservableCollection<Recenzija>();


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

        public async Task Init()
        {
            var list = await _service.Get<IEnumerable<Recenzija>>(null);
            //recenzije.Clear();
            //foreach (var recenzija in list)
            //{
            //    recenzije.Add(recenzija);
            //}

            if (Naslov == null)
            {
                recenzije.Clear();
                foreach (var recenzija in list)
                {
                    recenzije.Add(recenzija);
                }
            }
            else
            {
                RecenzijaSearchRequest search = new RecenzijaSearchRequest();
                search.Naslov = _searchnaslov;

                list = await _service.Get<IEnumerable<Recenzija>>(search);
                recenzije.Clear();
                foreach (var recenzija in list)
                {
                    recenzije.Add(recenzija);
                }
            }

        }

        public async Task Pretraga()
        {
            RecenzijaSearchRequest search = new RecenzijaSearchRequest
            {
                Naslov = _searchnaslov
            };

            var list = await _service.Get<IEnumerable<Recenzija>>(search);
            recenzije.Clear();
            foreach (Recenzija r in list)
            {
                recenzije.Add(r);
            }
        }

        //private  void RecenzijaSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    var searchterm = e.NewTextValue;
        //    //var searchterm = e.NewTextValue;
        //    if (string.IsNullOrWhiteSpace(searchterm))
        //    {
        //        searchterm = string.Empty;
        //    }
        //    // searchterm = searchterm.ToLowerInvariant();

        //    // var filteredItems = sourceitems.Where(value => value.Naslov.ToLowerInvariant().Contains(searchterm)).ToList();
        //    var filteredItems = sourceitems.Where(value => value.Naslov.Contains(searchterm)).ToList();

        //    if (string.IsNullOrWhiteSpace(searchterm))
        //    {
        //        filteredItems = sourceitems.ToList();
        //    }
        //    foreach (var value in sourceitems)
        //    {
        //        if (!filteredItems.Contains(value))
        //            RecenzijaList.Remove(value);
        //        else if (!RecenzijaList.Contains(value))
        //        {
        //            RecenzijaList.Add(value);
        //        }
        //    }
        //}
        //void OnTextChanged(object sender, EventArgs e)
        //{
        //    SearchBar searchBar = (SearchBar)sender;
        //    RecenzijaSearchRequest search = new RecenzijaSearchRequest();
        //    search.Naslov = _searchnaslov;

        //    //var keyword = searchBar.Text;
        //    //searchResults.ItemsSource =

        //    //searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        //}
    }
}
