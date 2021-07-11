using GamingHub2.MobileApp.Validators;
using GamingHub2.MobileApp.Validators.Rules;
using GamingHub2.MobileApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GamingHub2.MobileApp.ViewModels
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        APIService _serviceKorisnici = new APIService("Korisnici");

        #region Fields

        private ValidatableObject<string> username;
        private ValidatableObject<string> email;
        private ValidatableObject<string> ime;
        private ValidatableObject<string> prezime;
        private ValidatableObject<string> telefon;

        private ValidatablePair<string> password;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(LoginClicked);
            this.SignUpCommand = new Command(async () => await this.SignUpClicked());
        }
        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        /// 
        private Model.Requests.KorisniciRegistracijaRequest _korisnik = new Model.Requests.KorisniciRegistracijaRequest();
        public Model.Requests.KorisniciRegistracijaRequest Korisnik
        {
            get { return _korisnik; }
            set
            {
                SetProperty(ref _korisnik, value);
            }
        }

        public ValidatableObject<string> UserName
        {
            get
            {
                return this.username;
            }

            set
            {
                if (this.username == value)
                {
                    return;
                }

                this.SetProperty(ref this.username, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
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

        public ValidatableObject<string> Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.SetProperty(ref this.email, value);
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

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Initialize whether fieldsvalue are true or false.
        /// </summary>
        /// <returns>true or false </returns>
        public bool AreFieldsValid()
        {
            bool isEmail = this.Email.Validate();
            bool isUserNameValid = this.UserName.Validate();
            bool isPasswordValid = this.Password.Validate();
            bool isImeValid = this.Ime.Validate();
            bool isPrezimeValid = this.Prezime.Validate();
            bool isTelefonValid = this.Telefon.Validate();
            return isPasswordValid && isUserNameValid && isEmail && isImeValid && isPrezimeValid && isTelefonValid;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.UserName = new ValidatableObject<string>();
            this.Email = new ValidatableObject<string>();
            this.Password = new ValidatablePair<string>();
            this.Ime = new ValidatableObject<string>();
            this.Prezime = new ValidatableObject<string>();
            this.Telefon = new ValidatableObject<string>();
        }

        /// <summary>
        /// this method contains the validation rules
        /// </summary>
        private void AddValidationRules()
        {
            this.UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Korisničko ime je obavezno" });
            this.Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Lozinka je obavezna" });
            this.Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Unesite lozinku ponovo" });
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email je obavezan" });
            this.Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Email adresa nije u ispravnom formatu" });
            this.Ime.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Ime je obavezno" });
            this.Prezime.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Prezime je obavezno" });
            this.Telefon.Validations.Add(new IsValidRegexRule { ValidationMessage = "Telefonski broj mora biti u formatu +387 61 000 111", RegexRule = @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3,4}$" });
        }

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        private void LoginClicked()
        {
            Application.Current.MainPage = new LoginPage();
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        ///  private async Task SignUpClicked(object obj)
        private async Task SignUpClicked()
        {
            if (this.AreFieldsValid())
            {
                var korisnik = await _serviceKorisnici.Insert<Model.Korisnici>(new Model.Requests.KorisniciRegistracijaRequest
                {
                    KorisnickoIme = UserName.Value,
                    Email = Email.Value,
                    Ime = Ime.Value,
                    Prezime = Prezime.Value,
                    Password = Password.Item1.Value,
                    PasswordPotvrda = Password.Item2.Value,
                    Telefon = Telefon.Value,
                }, "Registracija");

                if (korisnik != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Potvrda", "Uspješno ste registrovani!", "OK");

                    APIService.Username = UserName.Value;
                    APIService.Password = Password.Item1.Value;
                    try
                    {
                        var TrenutniKorisnik = await _serviceKorisnici.Get<Model.Korisnici>(null, "MojProfil");

                        if (TrenutniKorisnik != null)
                        {
                            Application.Current.MainPage = new AppShell();
                            APIService.TrenutniKorisnik = TrenutniKorisnik;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nije potrebno prikazati gresku, sama ce se prikazati preko .Get()
                    }

                }
                else
                    await Application.Current.MainPage.DisplayAlert("Greska", "Postoji korisnik sa tim korisnickim imenom ili emailom.", "OK");

            }
        }

        #endregion
    }
}