using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayHelper.ViewModels;
using Xamarin.Forms;

namespace RayHelper
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var dataContext = new MapPageViewModel();
            BindingContext = dataContext;
        }
    }
}