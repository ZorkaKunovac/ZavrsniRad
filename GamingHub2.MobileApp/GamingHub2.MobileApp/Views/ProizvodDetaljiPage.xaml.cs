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
    public partial class ProizvodDetaljiPage : ContentPage
    {
        readonly ProizvodDetaljiViewModel model;
        public ProizvodDetaljiPage(Proizvod proizvod)
        {
            InitializeComponent();
            BindingContext = model = new ProizvodDetaljiViewModel() { Proizvod = proizvod };

        }
        public ProizvodDetaljiPage()
        {
            InitializeComponent();
            BindingContext = model = new ProizvodDetaljiViewModel() { Proizvod = null };

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

    }
}