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
        ProizvodDetaljiViewModel model = null;
        public ProizvodDetaljiPage(Proizvod proizvod)
        {
            InitializeComponent();
            BindingContext = model = new ProizvodDetaljiViewModel() { Proizvod = proizvod };

        }
    }
}