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

        public UserProfilePageViewModel()
        {
            IsUserAuthorized = false;
        }
    }
}