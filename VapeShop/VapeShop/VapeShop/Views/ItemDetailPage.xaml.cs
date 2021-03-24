using System.ComponentModel;
using VapeShop.ViewModels;
using Xamarin.Forms;

namespace VapeShop.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}