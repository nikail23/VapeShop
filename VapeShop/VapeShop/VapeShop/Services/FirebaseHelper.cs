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
    public class FirebaseHelper
    {
        private FirebaseClient firebase;

        public FirebaseHelper(string firebaseUrl)
        {
            firebase = new FirebaseClient(firebaseUrl);
        }

        public async Task<bool> AddVapeAsync(Vape item)
        {
            await firebase
              .Child("Vapes")
              .PostAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<List<Vape>> GetVapesAsync(bool forceRefresh = false)
        {
            return (await firebase
            .Child("Vapes")
            .OnceAsync<Vape>()).Select(item => new Vape
            {
                Name = item.Object.Name,
                Id = item.Object.Id,
                Cost = item.Object.Cost,
                BatteryPower = item.Object.BatteryPower,
                Description = item.Object.Description,
                Weight = item.Object.Weight,
                //Image = item.Object.Image
                ImageBytes = item.Object.ImageBytes
            }).ToList();
        }

        public async Task UpdateVape(Vape vape)
        {
            var toUpdatePerson = (await firebase
              .Child("Vapes")
              .OnceAsync<Vape>()).Where(a => a.Object.Id == vape.Id).FirstOrDefault();

            await firebase
              .Child("Vapes")
              .Child(toUpdatePerson.Key)
              .PutAsync(vape);
        }

        public async Task DeleteVape(string id)
        {
            var toDeletePerson = (await firebase
              .Child("Vapes")
              .OnceAsync<Vape>()).Where(a => a.Object.Id == id).FirstOrDefault();
            await firebase.Child("Vapes").Child(toDeletePerson.Key).DeleteAsync();
        }

        public async Task<Vape> GetVape(string id)
        {
            var vapes = await GetVapesAsync();
            await firebase
              .Child("Vapes")
              .OnceAsync<Vape>();
            return vapes.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
