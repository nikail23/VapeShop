using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using VapeShop.Models;
using Xamarin.Forms;

namespace VapeShop.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
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

        private Image GetImage(byte[] bytes)
        {
            if (bytes != null)
            {
                var image = new Image();
                var stream = new MemoryStream(bytes);
                image.Source = ImageSource.FromStream(() => { return stream; });
                return image;
            } else
            {
                return null;
            }

        }

        public Image Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public byte[] ImageBytes
        {
            get => bytes;
            set => SetProperty(ref bytes, value);
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

        public ItemDetailViewModel()
        {
            Title = "Подробнее";
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
                Image = GetImage(ImageBytes);
            }
            catch (Exception)
            {
                Debug.WriteLine("Не удалось загрузить информацию о вейпе");
            }
        }
    }
}
