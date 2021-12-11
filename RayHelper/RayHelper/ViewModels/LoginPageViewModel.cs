using System;
using System.Threading.Tasks;
using MvvmCross;
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

        protected override string ClassName => nameof(LoginPageViewModel);

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public IMvxAsyncCommand OpenMainPageCommand { get; }
        public IMvxAsyncCommand AuthorizeUserCommand { get; }

        private async Task OpenMainPageAsync()
        {
            Application.Current.MainPage = new RayMainPage();
        }
        
        private async Task AuthorizeUserAsync()
        {
            try
            {
                var user = await RayHelperClient.Login(_login, _password);
                AuthorizationService.AuthorizedUser = user;
                
                Application.Current.MainPage = new RayMainPage();
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(AuthorizeUserAsync)}," +
                        $"Error: {e}");
            }
        }
    }
}