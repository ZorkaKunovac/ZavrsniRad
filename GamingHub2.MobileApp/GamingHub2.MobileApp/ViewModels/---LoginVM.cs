using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    public class LoginVM:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");
        public LoginVM()
        {
            LoginCommand = new Command( async() => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;
            try
            {
                var TrenutniKorisnik = await _service.Get<Model.Korisnici>(null, "MojProfil");

                if (TrenutniKorisnik != null)
                {
                    Application.Current.MainPage = new AppShell();
                    APIService.TrenutniKorisnik = TrenutniKorisnik;
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
