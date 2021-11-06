using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace RayHelper.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private List<string> log;

        public List<string> Log
        {
            get => log;
            set => SetProperty(ref log, value);
        }
        
        private string _titleText;

        public string TitleText
        {
            get => _titleText;
            set => SetProperty(ref _titleText, value);
        }

        public IMvxAsyncCommand OpenRayProfileCommand { get; }
        public IMvxAsyncCommand OpenUserProfileCommand { get; }

        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public MainViewModel()
        {
            TitleText = "123";
            
            Log = new List<string>();
            
            OpenRayProfileCommand = new MvxAsyncCommand(OpenRayProfileAsync);
            OpenUserProfileCommand = new MvxAsyncCommand(OpenUserProfileAsync);
        }
        
        private async Task OpenRayProfileAsync()
        {
            Application.Current.MainPage = new NavigationPage(new RayProfilePage());
        }
        
        private async Task OpenUserProfileAsync()
        {
            Application.Current.MainPage = new NavigationPage(new UserProfilePage());
        }
    }
}