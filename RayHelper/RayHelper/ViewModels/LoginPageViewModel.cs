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
        }

        private async Task OpenMainPageAsync()
        {
            Application.Current.MainPage = new NavigationPage(new HospiceListPage());
        }

        private IMvxAsyncCommand openMainPageCommand;

        public IMvxAsyncCommand OpenMainPageCommand
        {
            get => openMainPageCommand;
            set => SetProperty(ref openMainPageCommand, value);
        }
    }
}