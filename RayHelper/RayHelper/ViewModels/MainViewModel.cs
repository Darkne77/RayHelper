using System.Collections.Generic;
using MvvmCross;
using MvvmCross.ViewModels;
using RayHelper.Models;
using Xamarin.Forms;

namespace RayHelper.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly AuthorizationService _authorizationService;
        public MainViewModel()
        {
            Log = new List<string>();
            _authorizationService = Mvx.IoCProvider.Resolve<AuthorizationService>();
        }
        
        private List<string> log;
        public List<string> Log
        {
            get => log;
            set => SetProperty(ref log, value);
        }
        
        public bool IsUserAuthorized
        {
            get => _authorizationService.IsUserAuthorized;
            set => _authorizationService.IsUserAuthorized = value;
        }
        
        public INavigation Navigation => Application.Current.MainPage.Navigation;
    }
}