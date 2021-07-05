using GamingHub2.MobileApp.ViewModels;
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
    public partial class RecenzijaDetaljiPage : ContentPage
    {
        RecenzijaDetaljiViewModel model = null;
        public RecenzijaDetaljiPage()
        {
            InitializeComponent();
        }
    }
}