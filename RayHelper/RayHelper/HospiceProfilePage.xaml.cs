using RayHelper.Models.Entities;
using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RayHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HospiceProfilePage : ContentPage
    {
        public HospiceProfilePage(Hospice hospice)
        {
            InitializeComponent();
            var dataContext = new HospiceProfilePageViewModel(hospice);
            BindingContext = dataContext;
        }
    }
}