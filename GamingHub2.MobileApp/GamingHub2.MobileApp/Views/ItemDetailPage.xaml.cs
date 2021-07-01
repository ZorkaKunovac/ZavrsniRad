using GamingHub2.MobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}