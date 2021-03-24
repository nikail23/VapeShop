using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;
using Xamarin.Forms;

namespace VapeShop.Services
{
    public class MockDataStore : IDataStore<Vape>
    {
        readonly List<Vape> vapes;

        public MockDataStore()
        {
            vapes = new List<Vape>()
            {
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "JUSTFOG MINIFIT", 
                    Description="В этом устройстве расположен встроенный атомайзер, " +
                    "который можно легко наполнить любой жидкостью по вкусу пользователя. " +
                    "Компактный набор не требует особых навыков, и поэтому может использоваться как новичками, " +
                    "так и продвинутыми пользователями. Устройство легко заряжается через USB провод. " +
                    "Компактный и эргономичный, прибор легко умещается на ладони.",
                    Cost = 1500,
                    BatteryPower = 370,
                    Weight = 87,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/JUSTFOG-MINIFIT.jpg" }
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Suorin Air", 
                    Description="В этом устройстве есть всё необходимое для пользователя – световой индикатор," +
                    " оповещающий о состоянии батареи и перезаправляемый картридж. " +
                    "Устройство оснащено входом USB для зарядки. " +
                    "Объём атомайзера в 2 мл позволяет использовать прибор в течение нескольких недель. " +
                    "Аккумулятор в 400 мАч прекрасно держит заряд. Его хватает для использования в течении 2 часов.",
                    Cost = 1700,
                    BatteryPower = 400,
                    Weight = 87,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/Suorin-Air.jpg" }
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "SMOK Trinity Alpha Resin Pod", 
                    Description="Устройство разработано так, чтобы с ним смог разобраться любой начинающий пользователь – " +
                    "присутствует возможность регулировки выходной мощности из трёх опций, " +
                    "яркий дизайн и удобная система заправки, которую разработчики уже использовали на других своих продуктах. " +
                    "На корпусе из информативных вещей расположен небольшой светодиодный индикатор," +
                    " позволяющий понять примерный уровень заряда аккумулятора.",
                    Cost = 2000,
                    BatteryPower = 1000,
                    Weight = 120,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/SMOK-Trinity-Alpha-Resin-Pod.jpg"}
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "JUSTFOG QPod", 
                    Description="Электронная сигарета от JUSTFOG позволяет насладиться сигаретами, " +
                    "не нанося вред окружающим. В комплектацию устройства входит несколько картриджей и сменный атомайзер," +
                    " который можно наполнить любимым ароматом. Дизайн был тщательно продуман производителем, в нём сочетается" +
                    " эргономика и стиль.",
                    Cost = 2300,
                    BatteryPower = 900,
                    Weight = 101,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/JUSTFOG-QPod.jpg"}
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "SMOK Novo 2 Pod Starter Kit", 
                    Description="Электронная сигарета оснащена достаточно мощным для своего класса аккумулятором и рассчитанная на работу со сменными картриджами семи типов. " +
                    "Дизайн новой версии остался узнаваемым и эргономичным, поэтому никаких сложностей с его использованием не будет. " +
                    "При этом производитель предлагает большой выбор расцветок, а также возможность кастомизации девайса при помощи специальных наклеек.",
                    Cost = 2500,
                    BatteryPower = 800,
                    Weight = 100,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/SMOK-Novo-2-Pod-Starter-Kit.png"}
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Eleaf iJust Mini Kit", 
                    Description="Этот девайс во многом продуман – от лаконичной упаковки до защиты от детей. " +
                    "Большой объём аккумулятора позволяет не так часто заряжать электронную сигарету. " +
                    "Коннектор 510 позволяет использовать в девайсе любые аксессуары, совместимые сданным коннектором.",
                    Cost = 2500,
                    BatteryPower = 1100,
                    Weight = 100,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/Eleaf-iJust-Mini-Kit.jpg"}
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Joyetech ESPION Tour with Cubis Max Kit", 
                    Description="В основе устройства находятся съёмные аккумуляторные батареи." +
                    " Таким образом пользователь сам может выбрать 2 батареи, вместимостью от 1850 мАч до 3600 мАч. " +
                    "В зависимости от приобретённых батарей и будет работать устройство. " +
                    "Максимальная мощность составляет 220 Вт.",
                    Cost = 2500,
                    BatteryPower = 3600,
                    Weight = 120,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/Joyetech-ESPION-Tour-with-Cubis-Max-Kit.jpg"}
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Vaporesso Target PM80", 
                    Description="Небольшой размер устройства никак не влияет на функционал электронной сигареты. " +
                    "Мощность батареи в 2000 мАч обеспечивает автономную работу до 5 часов. " +
                    "Стильный и эргономичный дизайн также являются преимуществом данной модели.",
                    Cost = 2500,
                    BatteryPower = 2000,
                    Weight = 250,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/Vaporesso-Target-PM80.jpg"}
                },
                new Vape { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = "Eleaf iJust 21700 Starter Kit",
                    Description="Это устройство сочетает в себе стильный дизайн и большой функционал. " +
                    "Пользователю предлагается самостоятельно приобрести батареи для аккумулятора. " +
                    "Таким образом каждый может выбрать автономное время работы. " +
                    "Объём атомайзера в 5,5 мл позволяет редко прибегать к заправке.",
                    Cost = 3500,
                    BatteryPower = 3600,
                    Weight = 150,
                    Image = new Image() { Source = "https://pc-consultant.ru/wp-content/uploads/2020/04/Eleaf-iJust-21700-Starter-Kit.jpg"}
                }
            };
        }


        public async Task<bool> AddVapeAsync(Vape item)
        {
            vapes.Add(item);

            return await Task.FromResult(true);
        }

        private int GetVapeId(Vape vape)
        {
            var result = 0;
            foreach (var buffer in vapes)
            {
                if (buffer.Id == vape.Id)
                {
                    return result;
                }
                result++;
            }
            return -1;
        }

        public async Task<bool> UpdateVapeAsync(Vape item)
        {
            var id = GetVapeId(item);
            if (id > -1)
            {
                vapes[id] = item;
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteVapeAsync(string id)
        {
            var oldItem = vapes.Where((Vape arg) => arg.Id == id).FirstOrDefault();
            vapes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Vape> GetVapeAsync(string id)
        {
            return await Task.FromResult(vapes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Vape>> GetVapesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(vapes);
        }
    }
}