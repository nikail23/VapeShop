using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;
using Xamarin.Forms;

namespace VapeShop.Services
{
    public class DataStore : IDataStore<Vape>
    {
        VapesService helper = new VapesService("https://vapeshop-3a628-default-rtdb.firebaseio.com/");

        public async Task<bool> AddVapeAsync(Vape item)
        {
            await helper.AddVapeAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateVapeAsync(Vape item)
        {
            await helper.UpdateVape(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteVapeAsync(string id)
        {
            await helper.DeleteVape(id);

            return await Task.FromResult(true);
        }

        public async Task<Vape> GetVapeAsync(string id)
        {
            return await helper.GetVape(id);
        }

        public async Task<List<Vape>> GetVapesAsync(bool forceRefresh = false)
        {
            return await helper.GetVapesAsync(forceRefresh);
        }
    }
}