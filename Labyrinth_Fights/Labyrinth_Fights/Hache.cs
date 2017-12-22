using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Hache : Weapon
    {
        public Hache(Position position) : base(position)
        {
            this.dégats = 10;
        }

        public override string ToString()
        {
            return ("H");
        }
    }
}
