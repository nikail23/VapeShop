using System;
using System.IO;
using VapeShop.Models;
using VapeShop.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VapeShop.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string id = Guid.NewGuid().ToString();
        private string name;
        private string description;
        private int cost;
        private int weight;
        private int battery;
        private string imageUrl;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            GetPhoto = new Command(GetPhotoAsync);
            TakePhoto = new Command(TakePhotoAsync);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string ImageUrl 
        { 
            get => imageUrl;
            set => SetProperty(ref imageUrl, value); 
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public int Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

        public int BatteryPower
        {
            get => battery;
            set => SetProperty(ref battery, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                Id = id,
                Name = Name,
                Description = Description,
                Weight = Weight,
                Cost = Cost,
                BatteryPower = BatteryPower,
                ImageUrl = ImageUrl
            };

            await DataStore.AddVapeAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void GetPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                using (var stream = new FileStream(photo.FullPath, FileMode.OpenOrCreate))
                {
                    ImageUrl = await ImagesService.StoreImage(stream, id);
                }
            }
            catch(Exception e)
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
                    ImageUrl = await ImagesService.StoreImage(stream, id);
                }
            }
            catch(Exception e)
            {
                await Shell.Current.DisplayAlert("Ошибка", e.Message, "");
            }
        }
    }
}
