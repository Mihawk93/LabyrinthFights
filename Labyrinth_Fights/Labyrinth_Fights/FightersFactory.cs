using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class FightersFactory
    {

        public Fighter CreateFighter(Position position)
        {
            Fighter fighter = new Fighter(position);
            return fighter;

        }
    }
}
