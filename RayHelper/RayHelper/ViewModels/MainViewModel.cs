using System.Collections.Generic;
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
        
        private INavigation navigation;
        public INavigation Navigation
        {
            get => navigation;
            set => SetProperty(ref navigation, value);
        }

        public MainViewModel()
        {
            Log = new List<string>();
            Navigation = Application.Current.MainPage.Navigation;
        }
    }
}