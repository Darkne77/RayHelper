using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class MapPageViewModel : MainViewModel
    {
        public MapPageViewModel()
        {
            OpenLocationOnMapCommand = new MvxAsyncCommand(OpenLocationOnMapAsync);

            Hospices = new List<Hospice>
            {
                new Hospice()
                {
                    Name = "Приют для животных, Бирюлёво Западное Продолжение названия и т.д.",
                    City = "Москва",
                    Street = "Харьковская улица",
                    HouseNumber = "1к3",
                    Latitude = 55.584126,
                    Longitude = 37.653343
                },
                new Hospice()
                {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица",
                HouseNumber = "1к3",
                Latitude = 55.584126,
                Longitude = 37.653343
            },
            new Hospice()
            {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица",
                HouseNumber = "1к3",
                Metro = "fdsjfhdsfsdi",
                Latitude = 55.584126,
                Longitude = 37.653343
            },
            new Hospice()
            {
                Name = "Приют, Бирюлёво Западное",
                City = "Москва",
                Street = "Харьковская улица ffdfgdgfd",
                HouseNumber = "1к3 6575585656",
                Latitude = 55.584126,
                Longitude = 37.653343
            }
            };
        }

        private List<Hospice> hospices;
        public List<Hospice> Hospices
        {
            get => hospices;
            set => SetProperty(ref hospices, value);
        }

        private IMvxAsyncCommand openLocationOnMapCommand;

        public IMvxAsyncCommand OpenLocationOnMapCommand
        {
            get => openLocationOnMapCommand;
            set => SetProperty(ref openLocationOnMapCommand, value);
        }

        private async Task OpenLocationOnMapAsync()
        {
            var location = new Location(55.584126, 37.653343);
            var options =  new MapLaunchOptions { Name = "Харьковская улица 1к3" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open
            }
        }
    }
}