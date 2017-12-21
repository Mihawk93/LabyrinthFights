using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Lance : Weapon
    {
        public Lance(int X, int Y) : base(X, Y)
        {
            this.dégats = 7;
        }

        public override string ToString()
        {
            return ("L");
        }
    }
}
