using GamingHub2.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GamingHub2.MobileApp.Views
{
    /// <summary>
    /// Page to add business details such as name, email address, and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        private readonly EditProfilePageViewModel model=null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditProfilePage" /> class.
        /// </summary>
        public EditProfilePage()
        {
            this.InitializeComponent();

            BindingContext = model = new EditProfilePageViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}