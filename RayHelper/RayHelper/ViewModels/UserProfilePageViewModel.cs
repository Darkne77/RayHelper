namespace RayHelper.ViewModels
{
    public class UserProfilePageViewModel : MainViewModel
    {
        private bool _isUserAuthorized;
        public bool IsUserAuthorized
        {
            get => _isUserAuthorized;
            set => SetProperty(ref _isUserAuthorized, value);
        }
        
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
            IsUserAuthorized = false;

            UserName = "Петр Францевич";
            Login = "petr_madi@rambler.ru";
        }
    }
}