using System.Collections.Generic;
using MvvmCross;
using MvvmCross.ViewModels;
using RayHelper.Models;
using Xamarin.Forms;

namespace RayHelper.ViewModels
{
    public abstract class MainViewModel : MvxViewModel
    {
        private readonly Logger _logger;

        public MainViewModel()
        {
            AuthorizationService = Mvx.IoCProvider.Resolve<AuthorizationService>();
            RayHelperClient = Mvx.IoCProvider.Resolve<RayHelperClient>();
            
            _logger = Mvx.IoCProvider.Resolve<Logger>();
        }

        protected abstract string ClassName { get; }
        
        public List<string> Log => _logger.Log;
        public RayHelperClient RayHelperClient { get; }
        public AuthorizationService AuthorizationService { get; }

        public INavigation Navigation => Application.Current.MainPage.Navigation;
    }
}