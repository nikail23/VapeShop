using System;

namespace VapeShop.Models
{
    public class Vape
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int BatteryPower { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public string Description { get; set; }

        public string GetCostString()
        {
            return Cost + " р.";
        }
    }
}