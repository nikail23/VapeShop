using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VapeShop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();


        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = picker.Items[picker.SelectedIndex];

            if (item == "English")
            {
                CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
            }

            if (item == "Русский")
            {
                CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("ru");
            }
        }
    }
}