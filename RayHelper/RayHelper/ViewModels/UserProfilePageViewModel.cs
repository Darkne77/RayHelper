using MvvmCross;
using RayHelper.Models;

namespace RayHelper.ViewModels
{
    public class UserProfilePageViewModel : MainViewModel
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public UserProfilePageViewModel()
        {
            UserName = "Петр Францевич";
            Login = "petr_madi@rambler.ru";
        }

        protected override string ClassName => nameof(UserProfilePageViewModel);
    }
}