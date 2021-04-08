using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Services
{
    public static class ImagesService
    {
        public static async Task<string> StoreImage(Stream imageStream, string imageName)
        {
            return await new FirebaseStorage("vapeshop-3a628.appspot.com")
                .Child("VapeImages")
                .Child(imageName)
                .PutAsync(imageStream);
        }

        public static async Task DeleteImageAsync(string fileName)
        {
            await new FirebaseStorage("vapeshop-3a628.appspot.com")
                 .Child("VapeImages")
                 .Child(fileName)
                 .DeleteAsync();

        }
    }
}
