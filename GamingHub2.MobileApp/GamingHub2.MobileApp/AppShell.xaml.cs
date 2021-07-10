using GamingHub2.MobileApp.ViewModels;
using GamingHub2.MobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GamingHub2.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(StripePaymentGatewayPage), typeof(StripePaymentGatewayPage));
            Routing.RegisterRoute(nameof(ProizvodDetaljiPage), typeof(ProizvodDetaljiPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
