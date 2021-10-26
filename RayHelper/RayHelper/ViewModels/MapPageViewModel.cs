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
        
        public async Task GetUserLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                if (location is not null)
                {
                    UserLocation = location;
                }
                Log.Add($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}