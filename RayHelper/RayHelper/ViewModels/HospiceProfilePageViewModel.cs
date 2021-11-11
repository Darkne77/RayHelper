using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class HospiceProfilePageViewModel : MainViewModel
    {
        private readonly Hospice _hospice;
        
        public HospiceProfilePageViewModel(Hospice hospice)
        {
            _hospice = hospice;

            OpenLocationOnMapCommand = new MvxAsyncCommand(OpenLocationOnMapAsync);
            OpenPhoneNumberCommand = new MvxAsyncCommand(OpenPhoneNumberAsync);
        }

        public string ClassName => nameof(HospiceProfilePageViewModel);
        public string Title => _hospice.Name;
        public string Phone => $"Тел.: {_hospice.Phone}";
        public string Address => _hospice.Address;

        public IMvxAsyncCommand OpenLocationOnMapCommand { get; }
        public IMvxAsyncCommand OpenPhoneNumberCommand { get; }

        private async Task OpenLocationOnMapAsync()
        {
            var location = new Location(_hospice.Latitude, _hospice.Longitude);
            var options =  new MapLaunchOptions { Name = _hospice.Name };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception e)
            {
                // No map application available to open
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(OpenLocationOnMapAsync)}," +
                        $"Error: {e}");
            }
        }

        private async Task OpenPhoneNumberAsync()
        {
            var phone = _hospice.Phone;
            if (!string.IsNullOrWhiteSpace(phone))
            {
                try
                {
                    PhoneDialer.Open(phone);
                }
                catch (FeatureNotSupportedException)
                {
                    var error = "Phone Dialer is not supported on this device.";
                    Log.Add($"Class name: {ClassName}," +
                            $"Method: {nameof(OpenPhoneNumberAsync)}," +
                            $"Error: {error}");
                }
                catch (Exception e)
                {
                    Log.Add($"Class name: {ClassName}," +
                            $"Method: {nameof(OpenPhoneNumberAsync)}," +
                            $"Error: {e}");
                }
            }
        }
    }
}