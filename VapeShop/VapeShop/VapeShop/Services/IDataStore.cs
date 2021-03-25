using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VapeShop.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddVapeAsync(T vape);
        Task<bool> UpdateVapeAsync(T vape);
        Task<bool> DeleteVapeAsync(string id);
        Task<T> GetVapeAsync(string id);
        Task<List<T>> GetVapesAsync(bool forceRefresh = false);
    }
}
