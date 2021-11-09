using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class HospiceListPageViewModel : MainViewModel
    {
        private List<Hospice> hospices;
        public List<Hospice> Hospices
        {
            get => hospices;
            set => SetProperty(ref hospices, value);
        }

        private Hospice selectedHospice;
        public Hospice SelectedHospice
        {
            get => selectedHospice;
            set => SetProperty(ref selectedHospice, value);
        }
        public IMvxAsyncCommand OpenHospiceProfileCommand { get; }
        
        public HospiceListPageViewModel()
        {
            OpenHospiceProfileCommand = new MvxAsyncCommand(OpenHospiceProfileAsync);

            Hospices = new List<Hospice>
            {
                new Hospice()
                {
                    Name = "Приют для животных, Бирюлёво Западное Продолжение названия и т.д.",
                    City = "Москва",
                    Street = "Харьковская улица",
                    HouseNumber = "1к3",
                    Latitude = 55.584126,
                    Longitude = 37.653343,
                    Phone = "+7(977)124-02-19"
                },
                new Hospice()
                {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица",
                HouseNumber = "1к3",
                Latitude = 55.584126,
                Longitude = 37.653343,
                Phone = "+7(977)124-02-19"
            },
            new Hospice()
            {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица",
                HouseNumber = "1к3",
                Metro = "fdsjfhdsfsdi",
                Latitude = 55.584126,
                Longitude = 37.653343,
                Phone = "+7(977)124-02-19"
            },
            new Hospice()
            {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица ffdfgdgfd",
                HouseNumber = "1к3 6575585656",
                Latitude = 55.584126,
                Longitude = 37.653343,
                Phone = "+7(977)124-02-19"
            }
            };
        }

        private async Task OpenHospiceProfileAsync()
        {
            await Navigation.PushAsync(new HospiceProfilePage(SelectedHospice));
        }
    }
}