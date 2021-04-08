using System;
using System.Collections.Generic;
using System.Text;
using VapeShop.Views;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using VapeShop.Services;
using System.Windows.Input;

namespace VapeShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UsersService usersService;

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public Command ToRegister { get; }
        public Command ToLogin { get; }

        public LoginViewModel()
        {
            usersService = new UsersService("https://vapeshop-3a628-default-rtdb.firebaseio.com/");

            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);

            ToLogin = new Command(NavToLogin);
            ToRegister = new Command(NavToRegister);
        }

        private async void OnLoginClicked()
        {
            
        }

        private async void OnRegisterClicked()
        {
            
        }

        private void NavToRegister()
        {
            IsRegister = true;
            IsLogin = false;
        }

        private void NavToLogin()
        {
            IsRegister = false;
            IsLogin = true;
        }

        private string username = "";
        public string Username { get => username; set => SetProperty(ref username, value); }

        private string login;
        public string Login { get => login; set => SetProperty(ref login, value); }

        private string password = "";
        public string Password { get => password; set => SetProperty(ref password, value); }

        private string passwordRepeat;
        public string PasswordRepeat { get => passwordRepeat; set => SetProperty(ref passwordRepeat, value); }

        private bool areCredentialsInvalid = false;
        public bool AreCredentialsInvalid { get => areCredentialsInvalid; set => SetProperty(ref areCredentialsInvalid, value); }

        private bool isRegister = false;
        public bool IsRegister { get => isRegister; set => SetProperty(ref isRegister, value); }

        private bool isLogin = true;
        public bool IsLogin { get => isLogin; set => SetProperty(ref isLogin, value); }
    }
}
