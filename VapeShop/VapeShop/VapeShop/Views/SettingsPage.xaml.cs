using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VapeShop.Resources;
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
                Thread.CurrentThread.CurrentUICulture = CrossMultilingual.Current.CurrentCultureInfo;
                AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            }

            if (item == "Русский")
            {
                CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("ru");
                Thread.CurrentThread.CurrentUICulture = CrossMultilingual.Current.CurrentCultureInfo;
                AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            }

            Title = AppResources.SettingsPageName;
            header.Text = AppResources.Language;
        }
    }
}