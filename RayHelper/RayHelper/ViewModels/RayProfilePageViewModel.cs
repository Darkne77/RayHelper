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

        protected override string ClassName => nameof(RayProfilePageViewModel);
        
        public string RayImageSource => "https://thumb.cloud.mail.ru/weblink/thumb/xw1/ttUm/GJmToF8nj/logo.jpg";
        public IMvxAsyncCommand OpenAboutUsLinkCommand { get; }
        public IMvxAsyncCommand OpenHelpWebSiteCommand { get; }


        private async Task OpenAboutUsLinkAsync()
        {
            var webSite = "https://rayfund.ru/about/";
            await OpenLinkAsync(webSite);
        }

        private async Task OpenHelpWebSiteAsync()
        {
            var webSite = "https://www.mos.ru/city/projects/blago/fond/rey/";
            await OpenLinkAsync(webSite);
        }

        private async Task OpenLinkAsync(string webSite)
        {
            try
            {
                await Browser.OpenAsync(webSite);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(OpenLinkAsync)}," +
                        $"Error: {ex}");
            }
        }
    }
}