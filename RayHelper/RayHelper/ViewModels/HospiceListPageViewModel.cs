﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
using Xamarin.Essentials;

namespace RayHelper.ViewModels
{
    public class HospiceListPageViewModel : MainViewModel
    {
        public HospiceListPageViewModel()
        {
            OpenLocationOnMapCommand = new MvxAsyncCommand(OpenLocationOnMapAsync);
            OpenHospiceProfileCommand = new MvxAsyncCommand<Hospice>(OpenHospiceProfileAsync);

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
        
        private IMvxAsyncCommand<Hospice> openHospiceProfileCommand;

        public IMvxAsyncCommand<Hospice> OpenHospiceProfileCommand
        {
            get => openHospiceProfileCommand;
            set => SetProperty(ref openHospiceProfileCommand, value);
        }

        private async Task OpenHospiceProfileAsync(Hospice hospice)
        {
            await Navigation.PushAsync(new HospiceProfilePage(hospice));
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