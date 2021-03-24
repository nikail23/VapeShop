using System;
using System.Collections.Generic;
using System.ComponentModel;
using VapeShop.Models;
using VapeShop.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VapeShop.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Vape Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}