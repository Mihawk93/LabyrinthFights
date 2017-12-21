using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Dague : Weapon
    {
        public Dague(int X, int Y) : base(X, Y)
        {
            this.dégats = 3;
        }

        public override string ToString()
        {
            return ("D");
        }
    }
}
