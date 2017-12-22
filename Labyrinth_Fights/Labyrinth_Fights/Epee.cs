using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Epee : Weapon
    {

        public Epee(Position position) : base(position)
        {
            this.dégats = 5;
        }

        public override string ToString()
        {
            return ("E") ;
        }
    }
}
