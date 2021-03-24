using System;
using System.Diagnostics;
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
        private int cost;
        private int battery;
        private string description;

        public string Id { get; set; }

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

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Cost = item.Cost;
                Description = item.Description;
                BatteryPower = item.BatteryPower;
            }
            catch (Exception)
            {
                Debug.WriteLine("Не удалось загрузить информацию о вейпе");
            }
        }
    }
}
