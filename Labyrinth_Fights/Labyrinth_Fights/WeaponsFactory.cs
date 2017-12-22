using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    public class WeaponsFactory
    {
        public Weapon CreateWeapon(String type, Position position)
        {
            Weapon weapon = null;

            if (type == "Epee")
                weapon = new Epee(position);
            if (type == "Hache")
                weapon = new Hache(position);
            if (type == "Lance")
                weapon = new Lance(position);
            if (type == "Dague")
                weapon = new Dague(position);
            return weapon;
        }
    }
}
