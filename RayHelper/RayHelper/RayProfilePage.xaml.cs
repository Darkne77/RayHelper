using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RayHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RayProfilePage : ContentPage
    {
        public RayProfilePage()
        {
            InitializeComponent();
            var dataContext = new RayProfilePageViewModel();
            BindingContext = dataContext;
        }
    }
}