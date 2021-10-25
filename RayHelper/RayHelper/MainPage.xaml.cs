﻿using System;
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
        private readonly MapPageViewModel dataContext;
        public MainPage()
        {
            InitializeComponent();
            dataContext = new MapPageViewModel();
            BindingContext = dataContext;
        }

        protected override void OnDisappearing()
        {
            if (dataContext.cts != null && !dataContext.cts.IsCancellationRequested)
                dataContext.cts.Cancel();
            base.OnDisappearing();
        }
    }
}