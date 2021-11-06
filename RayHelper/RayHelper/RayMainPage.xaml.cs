﻿using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RayHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RayMainPage : Shell
    {
        public RayMainPage()
        {
            InitializeComponent();
            var dataContext = new RayMainPageViewModel();
            BindingContext = dataContext;
        }
    }
}