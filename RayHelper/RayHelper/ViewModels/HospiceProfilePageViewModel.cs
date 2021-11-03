using RayHelper.Models;

namespace RayHelper.ViewModels
{
    public class HospiceProfilePageViewModel : MainViewModel
    {
        public readonly Hospice Hospice;
        
        public HospiceProfilePageViewModel(Hospice hospice)
        {
            this.Hospice = hospice;
        }
    }
}