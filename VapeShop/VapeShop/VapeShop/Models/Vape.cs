using Newtonsoft.Json;
using System;
using System.IO;
using Xamarin.Forms;

namespace VapeShop.Models
{
    public class Vape
    {
        public string Id { get; set; }
        public string Name { get; set; }
        private byte[] bytes;
        public byte[] ImageBytes
        {
            get 
            {
                return bytes;
            }
            set 
            {
                bytes = value;
                SetImage();
            } 
        } 
        public int BatteryPower { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
        [JsonIgnore]
        public Image Image { get; set; }
        public string Description { get; set; }

        private void SetImage()
        {
            Image = new Image();
            var stream = new MemoryStream(ImageBytes);
            Image.Source = ImageSource.FromStream(() => { return stream; });
        }
    }
}