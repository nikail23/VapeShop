using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Models;

namespace VapeShop.Services
{
    public class UsersService
    {
        private FirebaseClient firebase;

        private List<User> users;

        public UsersService(string firebaseUrl)
        {
            firebase = new FirebaseClient(firebaseUrl);
            users = new List<User>();
        }

        public async Task<string> CheckUserAsync(string login, string password)
        {
            var result = "";

            await LoadUsersAsync();

            foreach(var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    return user.Username;
                }
            }

            return result;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await firebase
              .Child("Users")
              .PostAsync(user);

            await LoadUsersAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            var deletingUser = (await firebase
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.Username == user.Username).FirstOrDefault();

            await firebase.Child("Users").Child(deletingUser.Key).DeleteAsync();

            await LoadUsersAsync();

            return await Task.FromResult(true);
        }

        private async Task LoadUsersAsync()
        {
            users = (await firebase
            .Child("Users")
            .OnceAsync<User>()).Select(item => new User
            {
               Username = item.Object.Username,
               Login = item.Object.Login,
               Password = item.Object.Password
            }).ToList();
        }
    }
}
