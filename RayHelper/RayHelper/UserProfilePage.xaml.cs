using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RayHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
            var dataContext = new UserProfilePageViewModel();
            BindingContext = dataContext;
        }
    }
}