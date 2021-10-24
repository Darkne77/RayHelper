using System.Collections.Generic;
using MvvmCross.ViewModels;

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

        public MainViewModel()
        {
            log = new List<string>();
        }
    }
}