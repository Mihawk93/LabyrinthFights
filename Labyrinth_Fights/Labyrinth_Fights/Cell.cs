using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Cell
    {
        Position position;
        public bool isEmpty;
        public bool isWall;
        public bool isExit;

        public Cell(Position position, bool isEmpty, bool isWall, bool isExit)
        {
            this.position = position;
            this.isEmpty = isEmpty;
            this.isWall = isWall;
            this.isExit = isExit;
        }


    }
}
