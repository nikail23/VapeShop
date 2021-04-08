using System;
using VapeShop.Services;
using VapeShop.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VapeShop
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStore>();
            MainPage = new AppShell();

            Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
