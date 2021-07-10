using GamingHub2.MobileApp.Validators;
using GamingHub2.MobileApp.Validators.Rules;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GamingHub2.MobileApp.ViewModels
{
    /// <summary>
    /// ViewModel for Business Registration Form page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class EditProfilePageViewModel : LoginViewModel
    {
        APIService _serviceKorisnici = new APIService("Korisnici");

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EditProfilePageViewModel" /> class
        /// </summary>
        public EditProfilePageViewModel()
        {
            this.InitializeProperties();
            this.SubmitCommand = new Command(async () => await this.SubmitClicked());
        }

        public async Task Init()
        {
            var entity = await _serviceKorisnici.Get<Model.Korisnici>(null, "MojProfil");
            if(entity.Slika == null || entity.Slika.Length == 0)
            {
                entity.Slika = File.ReadAllBytes("default_profile.png");
            }
            Korisnik = entity;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Full Name from user.
        /// </summary>

        private Model.Korisnici _korisnik;

        public Model.Korisnici Korisnik
        {
            get { return _korisnik; }
            set
            {
                SetProperty(ref _korisnik, value);
            }
        }

        private string _novaLozinka;

        public string NovaLozinka
        {
            get { return _novaLozinka; }
            set
            {
                SetProperty(ref _novaLozinka, value);
            }
        }


        private string _potvrdaLozinke;

        public string PotvrdaLozinke
        {
            get { return _potvrdaLozinke; }
            set { SetProperty(ref _potvrdaLozinke, value); }
        }


        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command is executed when the Submit button is clicked.
        /// </summary>
        public Command SubmitCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializzing the properties.
        /// </summary>
        private void InitializeProperties()
        {
        }

        /// <summary>
        /// Check name is valid or not
        /// </summary>
        /// <returns>Returns the fields are valid or not</returns>
        private bool AreFieldsValid()
        {
            return true;
        }

        /// <summary>
        /// Invoked when the Submit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async Task SubmitClicked()
        {
            if (this.AreFieldsValid())
            {
                var korisnik = await _serviceKorisnici.Update<Model.Korisnici>(APIService.TrenutniKorisnik.KorisnikId, new Model.Requests.KorisniciUpdateProfileRequest
                {
                    Ime = Korisnik.Ime,
                    Prezime = Korisnik.Prezime,
                    Password = NovaLozinka,
                    PasswordPotvrda = PotvrdaLozinke,
                    Telefon = Korisnik.Telefon,
                    Slika = new byte[0]
                }, "UpdateProfile");

                if(korisnik != null)
                {
                    if(!string.IsNullOrEmpty(NovaLozinka))
                    {
                        APIService.Password = NovaLozinka;
                    }
                    await Application.Current.MainPage.DisplayAlert("Potvrda", "Izmjene profila uspješno snimljene.", "OK");
                }
            }
        }

        #endregion
    }
}