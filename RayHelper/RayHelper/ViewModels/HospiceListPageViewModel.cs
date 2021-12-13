using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models.Entities;
using Xamarin.Essentials;

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
            LoadData();
        }

        private async void LoadData()
        {
            var hospices = await GetHospices();
            foreach (var hospice in hospices)
            {
                Hospices.Add(hospice);
            }
        }

        protected override string ClassName => nameof(HospiceListPageViewModel);

        private async Task<IEnumerable<Hospice>> GetHospices()
        {
            try
            {
                var hospices = await RayHelperClient.GetHospices().ConfigureAwait(false);
                hospices.Sort();
                return hospices;
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(GetHospices)}," +
                        $"Error: {e}");
            }
            return Enumerable.Empty<Hospice>();
        }

        private async Task OpenHospiceProfileAsync(Hospice hospice)
        {
            await Navigation.PushAsync(new HospiceProfilePage(hospice));
        }
    }
}