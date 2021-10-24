using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace RayHelper.ViewModels
{
    using Xamarin.Essentials;
    
    public class MapPageViewModel : MainViewModel
    {
        public CancellationTokenSource cts;

        private MvxAsyncCommand getUserLocationCommand;

        public MvxAsyncCommand GetUserLocationCommand
        {
            get => getUserLocationCommand;
            set => SetProperty(ref getUserLocationCommand, value);
        }

        public MapPageViewModel()
        {
            getUserLocationCommand = new MvxAsyncCommand(GetUserLocation);
        }
        
        public async Task<Location> GetUserLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            cts = new CancellationTokenSource();
            var location = new Location();
            try
            {
                location = await Geolocation.GetLocationAsync(request, cts.Token);
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
            return location;
        }
    }
}