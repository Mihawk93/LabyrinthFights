using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Hache : Weapon
    {
        public Hache(int X, int Y) : base(X, Y)
        {
            this.dégats = 10;
        }

        public override string ToString()
        {
            return ("H");
        }
    }
}
