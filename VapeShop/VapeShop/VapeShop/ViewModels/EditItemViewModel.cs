using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using VapeShop.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VapeShop.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class EditItemViewModel : BaseViewModel
    {
        private string itemId;
        private string name;
        private Image image;
        private byte[] bytes;
        private int cost;
        private int battery;
        private int weight;
        private string description;

        public string Id { get; set; }

        public byte[] ImageBytes
        {
            get => bytes;
            set => SetProperty(ref bytes, value);
        }

        private Image GetImage(byte[] bytes)
        {
            if (bytes != null)
            {
                var image = new Image();
                var stream = new MemoryStream(bytes);
                image.Source = ImageSource.FromStream(() => { return stream; });
                return image;
            }
            else
            {
                return null;
            }
        }

        public Image Image
        {
            get => image;
            set => SetProperty(ref image, value);
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
            Image = new Image();
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
                ImageBytes = vape.ImageBytes;
                Image = GetImage(bytes);
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
                //Image = Image
                ImageBytes = ImageBytes,
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
                Image.Source = ImageSource.FromFile(photo.FullPath);
                using (var fileStream = File.OpenRead(photo.FullPath))
                {
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, array.Length);
                    ImageBytes = array;
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
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                using (var fileStream = File.OpenRead(photo.FullPath))
                {
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, array.Length);
                    ImageBytes = array;
                }
                Image.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Ошибка", e.Message, "");
            }
        }
    }
}
