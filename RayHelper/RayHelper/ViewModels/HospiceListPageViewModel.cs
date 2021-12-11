using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models.Entities;

namespace RayHelper.ViewModels
{
    public class HospiceListPageViewModel : MainViewModel
    {
        private ObservableCollection<Hospice> _hospices;
        public ObservableCollection<Hospice> Hospices
        {
            get => _hospices;
            set => SetProperty(ref _hospices, value);
        }
        
        public IMvxAsyncCommand<Hospice> OpenHospiceProfileCommand { get; }

        public HospiceListPageViewModel()
        {
            OpenHospiceProfileCommand = new MvxAsyncCommand<Hospice>(OpenHospiceProfileAsync);

            Hospices = new ObservableCollection<Hospice>();
            GetHospices();
        }

        protected override string ClassName => nameof(HospiceListPageViewModel);

        private async void GetHospices()
        {
            try
            {
                var hospices = await RayHelperClient.GetHospices().ConfigureAwait(false);
                
                hospices.Sort();

                foreach (var hospice in hospices)
                {
                    Hospices.Add(hospice);
                }
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(GetHospices)}," +
                        $"Error: {e}");
            }
        }

        private async Task OpenHospiceProfileAsync(Hospice hospice)
        {
            await Navigation.PushAsync(new HospiceProfilePage(hospice));
        }
    }
}