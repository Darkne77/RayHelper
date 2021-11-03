using RayHelper.Models;
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
            BindingContext = hospice;
        }
    }
}