using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Commands;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class MapPageViewModel : MainViewModel
    {
        public CancellationTokenSource cts;

        public MapPageViewModel()
        {
            OpenMapCommand = new MvxAsyncCommand(OpenMap);
        }

        private Location userLocation;
        public Location UserLocation
        {
            get => userLocation;
            set => SetProperty(ref userLocation, value);
        }

        private IMvxAsyncCommand openMapCommand;

        public IMvxAsyncCommand OpenMapCommand
        {
            get => openMapCommand;
            set => SetProperty(ref openMapCommand, value);
        }

        private async Task OpenMap()
        {
            var location = new Location(47.645160, -122.1306032);
            var options =  new MapLaunchOptions { Name = "Microsoft Building 25" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }
    }
}