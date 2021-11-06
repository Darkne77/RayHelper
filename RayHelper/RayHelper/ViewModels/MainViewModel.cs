using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
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
        
        //TODO Remove or fix
        private string titleText;
        public string TitleText
        {
            get => titleText;
            set => SetProperty(ref titleText, value);
        }

        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public MainViewModel()
        {
            TitleText = "123";
            Log = new List<string>();
        }
    }
}