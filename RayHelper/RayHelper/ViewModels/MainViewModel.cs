using System.Collections.Generic;
using MvvmCross;
using MvvmCross.ViewModels;
using RayHelper.Models;
using Xamarin.Forms;

namespace RayHelper.ViewModels
{
    public abstract class MainViewModel : MvxViewModel
    {
        private readonly AuthorizationService _authorizationService;
        private readonly Logger _logger;
        public MainViewModel()
        {
            _authorizationService = Mvx.IoCProvider.Resolve<AuthorizationService>();
            _logger = Mvx.IoCProvider.Resolve<Logger>();
        }
        
        public List<string> Log => _logger.Log;

        public bool IsUserAuthorized
        {
            get => _authorizationService.IsUserAuthorized;
            set => _authorizationService.IsUserAuthorized = value;
        }
        
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        protected abstract string ClassName { get; }
    }
}