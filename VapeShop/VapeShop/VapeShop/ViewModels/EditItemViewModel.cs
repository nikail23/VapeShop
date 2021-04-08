using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using VapeShop.Models;
using VapeShop.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VapeShop.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class EditItemViewModel : BaseViewModel
    {
        private string itemId;
        private string name;
        private string imageUrl;
        private int cost;
        private int battery;
        private int weight;
        private string description;

        public string Id { get; set; }

        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }

        public int Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public int BatteryPower
        {
            get => battery;
            set => SetProperty(ref battery, value);
        }

        public int Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public EditItemViewModel()
        {
            Title = "Редактирование";
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            GetPhoto = new Command(GetPhotoAsync);
            TakePhoto = new Command(TakePhotoAsync);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public async void LoadItemId(string vapeId)
        {
            try
            {
                var vape = await DataStore.GetVapeAsync(vapeId);
                Id = vape.Id;
                Name = vape.Name;
                Cost = vape.Cost;
                Description = vape.Description;
                BatteryPower = vape.BatteryPower;
                Weight = vape.Weight;
                ImageUrl = vape.ImageUrl;
            }
            catch (Exception)
            {
                Debug.WriteLine("Не удалось загрузить информацию о вейпе");
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command TakePhoto { get; }
        public Command GetPhoto { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Vape newItem = new Vape()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Weight = Weight,
                Cost = Cost,
                BatteryPower = BatteryPower,
                ImageUrl = ImageUrl
            };

            await DataStore.UpdateVapeAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }

        private async void GetPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                using (var stream = new FileStream(photo.FullPath, FileMode.OpenOrCreate))
                {
                    ImageUrl = await ImagesService.StoreImage(stream, Id);
                }
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Ошибка", e.Message, "");
            }
        }

        private async void TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now:dd.MM.yyyy_hh.mm.ss}.png"
                });
                using (var stream = new FileStream(photo.FullPath, FileMode.OpenOrCreate))
                {
                    ImageUrl = await ImagesService.StoreImage(stream, Id);
                }
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Ошибка", e.Message, "");
            }
        }
    }
}
