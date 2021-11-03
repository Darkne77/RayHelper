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
        }
        
        private IMvxAsyncCommand _openLocationOnMapCommand;
        public IMvxAsyncCommand OpenLocationOnMapCommand
        {
            get => _openLocationOnMapCommand;
            set => SetProperty(ref _openLocationOnMapCommand, value);
        }
        
        private async Task OpenLocationOnMapAsync()
        {
            var location = new Location(_hospice.Latitude, _hospice.Longitude);
            var options =  new MapLaunchOptions { Name = _hospice.Name };

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