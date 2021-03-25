using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using VapeShop.Models;
using VapeShop.Views;
using Xamarin.Forms;

namespace VapeShop.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Vape _selectedItem;

        public ObservableCollection<Vape> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Vape> DeleteVape { get; }
        public Command<Vape> EditButtonClicked { get; }
        public Command<Vape> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Vape Shop";
            Items = new ObservableCollection<Vape>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            DeleteVape = new Command<Vape>(OnDeletingVape);
            EditButtonClicked = new Command<Vape>(OnEditButtonClicked);
            ItemTapped = new Command<Vape>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetVapesAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Vape SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public async void OnDeletingVape(Vape vape)
        {
            await DataStore.DeleteVapeAsync(vape.Id);
            await ExecuteLoadItemsCommand();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnEditButtonClicked(Vape item)
        {
            if (item == null)
                return;

            // This will push the EditItemPage onto the navigation stack
            string path = $"{nameof(EditItemPage)}?{nameof(EditItemViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(path);
        }

        async void OnItemSelected(Vape item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            string path = $"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(path);
        }
    }
}