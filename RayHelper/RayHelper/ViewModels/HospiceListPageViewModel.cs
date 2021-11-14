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
        private List<Hospice> _hospices;
        public List<Hospice> Hospices
        {
            get => _hospices;
            set => SetProperty(ref _hospices, value);
        }

        private Hospice _selectedHospice;
        public Hospice SelectedHospice
        {
            get => _selectedHospice;
            set => SetProperty(ref _selectedHospice, value);
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
                    Mobile = "+7(977)124-02-19",
                    Website = "https://yandex.ru/"
                },
                new Hospice()
                {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица",
                HouseNumber = "1к3",
                Latitude = 55.584126,
                Longitude = 37.653343,
                Mobile = "+7(977)124-02-19",
                Website = "https://yandex.ru/"
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
                Mobile = "+7(977)124-02-19",
                Website = "https://yandex.ru/"
            },
            new Hospice()
            {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица ffdfgdgfd",
                HouseNumber = "1к3 6575585656",
                Latitude = 55.584126,
                Longitude = 37.653343,
                Mobile = "+7(977)124-02-19",
                Website = "https://yandex.ru/"
            }
            };
        }

        private async Task OpenHospiceProfileAsync()
        {
            await Navigation.PushAsync(new HospiceProfilePage(SelectedHospice));
        }
    }
}