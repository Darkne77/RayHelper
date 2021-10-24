using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

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

            var userLocation = dataContext.GetUserLocation().Result;
            var position = new Position(userLocation.Latitude, userLocation.Longitude);
            var mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1));
            Map.MoveToRegion(mapSpan);
        }

        protected override void OnDisappearing()
        {
            if (dataContext.cts != null && !dataContext.cts.IsCancellationRequested)
                dataContext.cts.Cancel();
            base.OnDisappearing();
        }
    }
}