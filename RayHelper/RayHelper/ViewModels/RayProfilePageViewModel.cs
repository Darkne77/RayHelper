using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class RayProfilePageViewModel : MainViewModel
    {
        public RayProfilePageViewModel()
        {
            OpenAboutUsLinkCommand = new MvxAsyncCommand(OpenAboutUsLinkAsync);
        }
        
        public IMvxAsyncCommand OpenAboutUsLinkCommand { get; set; }
        
        private async Task OpenAboutUsLinkAsync()
        {
            var webSite = "https://rayfund.ru/about/";
            try
            {
                await Browser.OpenAsync(webSite);
            }
            catch(Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}