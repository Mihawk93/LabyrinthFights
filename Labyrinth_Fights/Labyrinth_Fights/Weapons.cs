using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    public class Weapons
    {
        WeaponsFactory factory;
        Dictionary<int, string> weaponsDictionary = new Dictionary<int, string>();

        public void InitDictionary()
        {
            weaponsDictionary.Add(0, "Epee");
            weaponsDictionary.Add(1, "Hache");
            weaponsDictionary.Add(2, "Lance");
            weaponsDictionary.Add(3, "Dague");
        }

        public Weapons(WeaponsFactory Factory)
        {
            InitDictionary();
            this.factory = Factory;
        }

        public Weapon AskForWeapon()
        {
            Weapon weapon;
            Random rand = new Random();
            string type = weaponsDictionary[rand.Next(4)];
            weapon = factory.CreateWeapon(type);
            return weapon;
        }
    }
}
