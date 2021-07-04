using GamingHub2.MobileApp.ViewModels;
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
        private readonly string[] sourceitems= new []
        {
            "Mohamad","Ahmed","Karim","Hasan","Hamed","Marwen"
        };
        public ObservableCollection<string> MyItems { get; set; }
        public RecenzijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RecenzijaViewModel();
            MyItems = new ObservableCollection<string>(sourceitems);
            //BindingContext=this;

            //List<string> names = new List<string>
            //{
            //model.Naslov
            //};
            //searchResults.ItemsSource = names;
        }
        // void RecenzijaSearchBar_TextChanged( object sender,TextChangedEventArgs e)
        //{
        //    var keyword = RecenzijaSearchBar.Text;
        //}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void RecenzijaSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchterm = e.NewTextValue;
            if(string.IsNullOrWhiteSpace(searchterm))
            {
                searchterm = string.Empty;
            }
            searchterm = searchterm.ToLowerInvariant();

            var filteredItems = sourceitems.Where(value => value.ToLowerInvariant().Contains(searchterm)).ToList();
            if(string.IsNullOrWhiteSpace(searchterm))
            {
                filteredItems = sourceitems.ToList();
            }
            foreach (var value in sourceitems)
            {
                if (!filteredItems.Contains(value))
                    MyItems.Remove(value);
                else if(!MyItems.Contains(value))
                {
                    MyItems.Add(value);
                }
            }
        }
    }
}