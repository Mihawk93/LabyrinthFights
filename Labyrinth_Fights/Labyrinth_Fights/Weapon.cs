using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    public class Weapon
    {
        protected int dégats;
        int coord_X;
        int coord_Y;

        public Weapon(int X, int Y)
        {
            this.coord_X = X;
            this.coord_Y = Y;
        }
    }
}
