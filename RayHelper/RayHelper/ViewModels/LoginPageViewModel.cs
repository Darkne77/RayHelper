using System.Threading.Tasks;
using MvvmCross.Commands;
using Xamarin.Forms;

namespace RayHelper.ViewModels
{
    public class LoginPageViewModel : MainViewModel
    {
        public LoginPageViewModel()
        {
            OpenMainPageCommand = new MvxAsyncCommand(OpenMainPageAsync);
            AuthorizeUserCommand = new MvxAsyncCommand(AuthorizeUserAsync);
        }
        
        public IMvxAsyncCommand OpenMainPageCommand { get; }
        public IMvxAsyncCommand AuthorizeUserCommand { get; }

        private async Task OpenMainPageAsync()
        {
            Application.Current.MainPage = new RayMainPage();
        }
        
        private async Task AuthorizeUserAsync()
        {
            IsUserAuthorized = true;
            Application.Current.MainPage = new RayMainPage();
        }
    }
}