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
        public List<Weapon> ListWeapons = new List<Weapon>();

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
            Random rand = new Random();
            int index = 0;
            for (int i=0; i<4;i++)
            {
                index = 0;
                index = rand.Next(4);
            }
            
            Weapon weapon = null;
            string type = catalogueArmes[index];
            weapon = factory.CreateWeapon(type,position);
            ListWeapons.Add(weapon);
            index = rand.Next(4);
            return weapon;
        }
    }
}
