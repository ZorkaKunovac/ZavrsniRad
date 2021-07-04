using GamingHub2.MobileApp.ViewModels;
using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamingHub2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecenzijaPage : ContentPage
    {
        private RecenzijaViewModel model = null;
        //List<string> names = new List<string>
        //{
        //    "Mohamad","Ahmed","Karim","Hasan","Hamed","Marwen"
        //};
        //private readonly APIService _service = new APIService("Recenzija");
        //public ObservableCollection<Recenzija> RecenzijaList { get; set; } = new ObservableCollection<Recenzija>();

        //public ObservableCollection<Recenzija> sourceitems = new ObservableCollection<Recenzija>();
        //public async Task GetRecenzije()
        //{

        //    var list = await _service.Get<IEnumerable<Recenzija>>(null);
        //    RecenzijaList.Clear();
        //    sourceitems.Clear();
        //    foreach (var recenzija in list)
        //    {
        //        RecenzijaList.Add(recenzija);
        //        sourceitems.Add(recenzija);
        //    }
        //}


        public RecenzijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RecenzijaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
          //  model.onappear
        }

        //private void RecenzijaSearchBar_TextChanged(object sender, TextChangedEventArgs e)
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
        //private void RecenzijaSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var searchterm = e.NewTextValue;
        //    if (string.IsNullOrWhiteSpace(searchterm))
        //    {
        //        searchterm = string.Empty;
        //    }
        //    searchterm = searchterm.ToLowerInvariant();

        //    var filteredItems = sourceitems.Where(value => value.Naslov.ToLowerInvariant().Contains(searchterm)).ToList();
        //    if (string.IsNullOrWhiteSpace(searchterm))
        //    {
        //        filteredItems = sourceitems.ToList();
        //    }
        //    foreach (var value in sourceitems)
        //    {
        //        if (!filteredItems.Contains(value))
        //            MyItems.Remove(value);
        //        else if (!MyItems.Contains(value))
        //        {
        //            MyItems.Add(value);
        //        }
        //    }
        //}
    }
}