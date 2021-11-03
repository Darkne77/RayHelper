using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayHelper.Models;
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