using GamingHub2.MobileApp.ViewModels;
using GamingHub2.Model;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GamingHub2.MobileApp.Views
{
    /// <summary>
    /// Article detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleDetailPage
    {
        ArticleDetailPageViewModel model = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GamingHub2.MobileApp.Views.ArticleDetailPage"/> class.
        /// </summary>
        //public ArticleDetailPage(Recenzija recenzija)
        //{
        //    this.InitializeComponent();
        //    this.BindingContext = ArticleDetailPageViewModel.BindingContext;
        //    BindingContext = model = new ArticleDetailPageViewModel() { Recenzija = recenzija };

        //}
        public ArticleDetailPage(Recenzija recenzija)
        {
            InitializeComponent();
            BindingContext = model = new ArticleDetailPageViewModel() { Recenzija = recenzija };

        }
    }
}