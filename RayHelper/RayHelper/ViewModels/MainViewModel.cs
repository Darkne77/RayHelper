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

        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public MainViewModel()
        {
            Log = new List<string>();
        }
    }
}