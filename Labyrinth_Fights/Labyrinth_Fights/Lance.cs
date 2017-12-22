using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Lance : Weapon
    {
        public Lance(Position position) : base(position)
        {
            this.dégats = 7;
        }

        public override string ToString()
        {
            return ("L");
        }
    }
}
