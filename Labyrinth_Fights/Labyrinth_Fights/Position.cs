using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    public class Position
    {
        public int coord_X;
        public int coord_Y;

        public Position(int X, int Y)
        {
            this.coord_X = X;
            this.coord_Y = Y; 
        }

        public override string ToString()
        {
            return "{"+this.coord_X+","+this.coord_Y+"}";
        }
    }
}
