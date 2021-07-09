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
    public partial class HistorijaNarudzbiDetaljiPage : ContentPage
    {
        HistorijaNarudzbiDetaljiViewModel model = null;

        public HistorijaNarudzbiDetaljiPage(Narudzba narudzba)
        {
            InitializeComponent();
            BindingContext = model = new HistorijaNarudzbiDetaljiViewModel() { Narudzba = narudzba };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}