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
        public RecenzijaPage()
        {
            InitializeComponent();
            BindingContext = model = new RecenzijaViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

    }
}