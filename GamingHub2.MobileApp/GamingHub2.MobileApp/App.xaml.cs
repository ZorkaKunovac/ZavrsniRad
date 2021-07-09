using GamingHub2.MobileApp.Services;
using GamingHub2.MobileApp.Views;
using Stripe;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace GamingHub2.MobileApp
{
    public partial class App : Xamarin.Forms.Application
    {
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            StripeConfiguration.ApiKey = "sk_test_51JB86lFLTqTMYcd1irDiRmWtHSxEMhyYcPVL1DoPK5HLcVt3oji5hXXEhkOGQOOc5KTUj79WpqyumTk6kp9QlHLl003QJK37cA";

            MainPage = new LoginPage();
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
