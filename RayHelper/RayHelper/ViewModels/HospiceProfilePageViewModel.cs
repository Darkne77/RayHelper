using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class HospiceProfilePageViewModel : MainViewModel
    {
        public Hospice Hospice { get; set; }
        
        public HospiceProfilePageViewModel(Hospice hospice)
        {
            Hospice = hospice;
            
            OpenLocationOnMapCommand = new MvxAsyncCommand(OpenLocationOnMapAsync);
        }
        
        private IMvxAsyncCommand openLocationOnMapCommand;

        public IMvxAsyncCommand OpenLocationOnMapCommand
        {
            get => openLocationOnMapCommand;
            set => SetProperty(ref openLocationOnMapCommand, value);
        }
        
        private async Task OpenLocationOnMapAsync()
        {
            var location = new Location(Hospice.Latitude, Hospice.Longitude);
            var options =  new MapLaunchOptions { Name = Hospice.Name };

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