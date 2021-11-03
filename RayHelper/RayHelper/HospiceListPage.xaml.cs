using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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