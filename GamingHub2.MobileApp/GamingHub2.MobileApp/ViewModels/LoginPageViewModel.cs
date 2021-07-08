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
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        #region Fields

        private ValidatableObject<string> password;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(async () => await this.LoginClicked());
            this.SignUpCommand = new Command(this.SignUpClicked);
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public ValidatableObject<string> Password
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

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Check the password is null or empty
        /// </summary>
        /// <returns>Returns the fields are valid or not</returns>
        public bool AreFieldsValid()
        {
            bool isUserNameValid = this.UserName.Validate();
            bool isPasswordValid = this.Password.Validate();
            return isUserNameValid && isPasswordValid;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Password = new ValidatableObject<string>();
        }

        /// <summary>
        /// Validation rule for password
        /// </summary>
        private void AddValidationRules()
        {
            this.UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Korisničko ime je obavezno" });
            this.Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Lozinka je obavezna" });
        }

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        private async Task LoginClicked()
        {
            if (this.AreFieldsValid())
            {
                APIService.Username = UserName.Value;
                APIService.Password = Password.Value;
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

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        private void SignUpClicked()
        {
            Application.Current.MainPage = new SignUpPage();
        }

        #endregion
    }
}