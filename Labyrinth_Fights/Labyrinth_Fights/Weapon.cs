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
        public Position pos;

        public Weapon(Position theposition)
        {
            this.pos = theposition;
        }
    }
}
