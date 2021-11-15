﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using RayHelper.Models;
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

        private Hospice _selectedHospice;
        public Hospice SelectedHospice
        {
            get => _selectedHospice;
            set => SetProperty(ref _selectedHospice, value);
        }
        public IMvxAsyncCommand OpenHospiceProfileCommand { get; }

        private readonly DbContext _dbContext;
        
        public HospiceListPageViewModel()
        {
            OpenHospiceProfileCommand = new MvxAsyncCommand(OpenHospiceProfileAsync);
            Hospices = new ObservableCollection<Hospice>();

            _dbContext = new DbContext();
            
            LoadData();
        }
        
        public string ClassName => nameof(HospiceListPageViewModel);

        private async void LoadData()
        {
            try
            {
                var hospices = await _dbContext.GetHospices().ConfigureAwait(false);
                
                foreach (var hospice in hospices)
                {
                    Hospices.Add(hospice);
                }
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(LoadData)}," +
                        $"Error: {e}");
            }
        }

        private async Task OpenHospiceProfileAsync()
        {
            await Navigation.PushAsync(new HospiceProfilePage(SelectedHospice));
        }
    }
}