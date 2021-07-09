using GamingHub2.MobileApp.ViewModels;
using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamingHub2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistorijaNarudzbi : ContentPage
    {
        private HistorijaNarudzbiViewModel model = null;

        public HistorijaNarudzbi()
        {
            InitializeComponent();
            BindingContext = model = new HistorijaNarudzbiViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Narudzba;

           await Navigation.PushAsync(new HistorijaNarudzbiDetaljiPage(item));
        }
    }
}