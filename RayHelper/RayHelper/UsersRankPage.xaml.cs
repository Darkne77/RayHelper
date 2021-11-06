using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RayHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersRankPage : ContentPage
    {
        public UsersRankPage()
        {
            InitializeComponent();
            var dataContext = new UsersRankPageViewModel();
            BindingContext = dataContext;
        }
    }
}