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
        Dictionary<int, string> catalogueArmes = new Dictionary<int, string>();
        List<Weapon> ListWeapons = new List<Weapon>();

        public void InitDictionary()
        {
            catalogueArmes.Add(0, "Epee");
            catalogueArmes.Add(1, "Hache");
            catalogueArmes.Add(2, "Lance");
            catalogueArmes.Add(3, "Dague");
        }

        public Weapons(WeaponsFactory Factory)
        {
            InitDictionary();
            this.factory = Factory;
        }

        public Weapon AskForWeapon(Position position)
        {
            Weapon weapon = null;
            Random rand = new Random();
            string type = catalogueArmes[rand.Next(4)];
            weapon = factory.CreateWeapon(type,position);
            ListWeapons.Add(weapon);
            return weapon;
        }
    }
}
