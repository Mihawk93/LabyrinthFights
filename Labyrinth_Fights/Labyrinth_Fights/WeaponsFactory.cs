using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    public class WeaponsFactory
    {
        public Weapon CreateWeapon(String type,int X, int Y)
        {
            Weapon weapon = null;

            if (type == "Epee")
                weapon = new Epee(X,Y);
            if (type == "Hache")
                weapon = new Hache(X,Y);
            if (type == "Lance")
                weapon = new Lance(X,Y);
            if (type == "Dague")
                weapon = new Dague(X,Y);
            return weapon;
        }
    }
}
