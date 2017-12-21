using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Epee : Weapon
    {

        public Epee(int X, int Y) : base(X, Y)
        {
            this.dégats = 5;
        }

        public override string ToString()
        {
            return ("E") ;
        }
    }
}
