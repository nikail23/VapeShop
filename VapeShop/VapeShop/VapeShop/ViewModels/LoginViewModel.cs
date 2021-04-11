using System;
using System.Collections.Generic;
using System.Text;
using VapeShop.Views;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using VapeShop.Services;
using System.Windows.Input;
using VapeShop.Models;

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
            var loginResult = await usersService.ValidateLoginAsync(Login, Password);
            if (loginResult)
            {
                await Shell.Current.GoToAsync("//Catalog");
            } else
            {
                ErrorText = "Проверьте правильность введенных данных!";
                AreCredentialsInvalid = true;
            }
        }

        private async void OnRegisterClicked()
        {
            var isExistedUser = await usersService.CheckUserAsync(Username);
            if (!isExistedUser)
            {
                var user = new User() { Username = Username, Login = Login, Password = Password };

                await usersService.AddUserAsync(user);

                NavToLogin();
            } else
            {
                ErrorText = "Пользователь с введенными данными уже существует!";
                AreCredentialsInvalid = true;
            }
        }

        private void NavToRegister()
        {
            IsRegister = true;
            IsLogin = false;
            AreCredentialsInvalid = false;
        }

        private void NavToLogin()
        {
            IsRegister = false;
            IsLogin = true;
            AreCredentialsInvalid = false;
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

        private string errorText = "";
        public string ErrorText { get => errorText; set => SetProperty(ref errorText, value); }

        private bool isRegister = false;
        public bool IsRegister { get => isRegister; set => SetProperty(ref isRegister, value); }

        private bool isLogin = true;
        public bool IsLogin { get => isLogin; set => SetProperty(ref isLogin, value); }
    }
}
