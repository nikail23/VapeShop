using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Resources;
using VapeShop.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VapeShop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoogleMapsPage : ContentPage
    {
        public GoogleMapsPage()
        {
            InitializeComponent();
            BindingContext = new GoogleMapsViewModel();

            Title = AppResources.GooglePageName;
        }
    }
}