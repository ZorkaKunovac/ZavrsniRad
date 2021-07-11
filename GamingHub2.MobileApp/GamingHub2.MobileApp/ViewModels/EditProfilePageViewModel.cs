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

        private ValidatableObject<string> ime;
        private ValidatableObject<string> prezime;
        private ValidatableObject<string> telefon;

        private ValidatablePair<string> password;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EditProfilePageViewModel" /> class
        /// </summary>
        public EditProfilePageViewModel()
        {
            this.SubmitCommand = new Command(async () => await this.SubmitClicked());
        }
        #endregion

        public async Task Init()
        {
            var entity = await _serviceKorisnici.Get<Model.Korisnici>(null, "MojProfil");
            if (entity.Slika == null || entity.Slika.Length == 0)
            {
                entity.Slika = File.ReadAllBytes("default_profile.png");
            }
            Korisnik = entity;

            this.InitializeProperties();
            this.AddValidationRules();
        }


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

        public ValidatablePair<string> Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }

        public ValidatableObject<string> Ime
        {
            get
            {
                return this.ime;
            }

            set
            {
                if (this.ime == value)
                {
                    return;
                }

                this.SetProperty(ref this.ime, value);
            }
        }
        public ValidatableObject<string> Prezime
        {
            get
            {
                return this.prezime;
            }

            set
            {
                if (this.prezime == value)
                {
                    return;
                }

                this.SetProperty(ref this.prezime, value);
            }
        }

        public ValidatableObject<string> Telefon
        {
            get
            {
                return this.telefon;
            }

            set
            {
                if (this.telefon == value)
                {
                    return;
                }

                this.SetProperty(ref this.telefon, value);
            }
        }



        #endregion

        #region Commands

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
            this.Password = new ValidatablePair<string>();
            this.Ime = new ValidatableObject<string>() { Value = Korisnik.Ime };
            this.Prezime = new ValidatableObject<string>() { Value = Korisnik.Prezime };
            this.Telefon = new ValidatableObject<string>() { Value = Korisnik.Telefon };
        }

        /// <summary>
        /// Check name is valid or not
        /// </summary>
        /// <returns>Returns the fields are valid or not</returns>
        private bool AreFieldsValid()
        {
            bool isPasswordValid = string.IsNullOrEmpty(this.password.Item1.Value) || this.Password.Validate();
            bool isImeValid = this.Ime.Validate();
            bool isPrezimeValid = this.Prezime.Validate();
            bool isTelefonValid = this.Telefon.Validate();
            return isPasswordValid && isImeValid && isPrezimeValid && isTelefonValid;

        }

        private void AddValidationRules()
        {
            this.Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Lozinka je obavezna" });
            this.Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Unesite lozinku ponovo" });
            this.Ime.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Ime je obavezno" });
            this.Prezime.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Prezime je obavezno" });
            this.Telefon.Validations.Add(new IsValidRegexRule { ValidationMessage = "Telefonski broj mora biti u formatu +387 61 000 111", RegexRule = @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3,4}$" });
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
                    Ime = Ime.Value,
                    Prezime = Prezime.Value,
                    Password = Password.Item1.Value,
                    PasswordPotvrda = Password.Item2.Value,
                    Telefon = Telefon.Value
                }, "UpdateProfile");

                if (korisnik != null)
                {

                    if (!string.IsNullOrEmpty(Password.Item1.Value))
                    {
                        APIService.Password = Password.Item1.Value;
                    }
                    await Application.Current.MainPage.DisplayAlert("Potvrda", "Izmjene profila uspješno snimljene.", "OK");

                }
                else
                    await Application.Current.MainPage.DisplayAlert("Greska", "Promjena nije uspjesna", "OK");
            }
        }

        #endregion
    }
}