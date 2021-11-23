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
            OpenHelpWebSiteCommand = new MvxAsyncCommand(OpenHelpWebSiteAsync);
        }

        public IMvxAsyncCommand OpenAboutUsLinkCommand { get; }
        public IMvxAsyncCommand OpenHelpWebSiteCommand { get; }
        
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
        
        private async Task OpenHelpWebSiteAsync()
        {
            var webSite = "https://www.mos.ru/city/projects/blago/fond/rey/";
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