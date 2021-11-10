using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RayHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HospiceListPage : ContentPage
    {
        public HospiceListPage()
        {
            InitializeComponent();
            var dataContext = new HospiceListPageViewModel();
            BindingContext = dataContext;
        }
    }
}