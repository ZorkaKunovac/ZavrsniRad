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
                await _service.Get<dynamic>(null);

                List<Model.Korisnici> listKorisnici = await _service.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { KorisnickoIme = APIService.Username });
                Model.Korisnici korisnik = listKorisnici.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();
                if (korisnik != null)
                {
                    Application.Current.MainPage = new Page();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greska","Pogrešno korisničko ime ili lozinka!","OK");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
