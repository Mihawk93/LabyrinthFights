using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Labyrinthe
    {
        List<Position> nombreDePositionLibre;
        int[,] map;

        public void SetNombreDePositionLibre()
        {
            for(int i=0; i<map.GetLength(0);i++)
            {
                for(int j=0;j<map.GetLength(1);j++)
                {
                    if (map[i, j] == 0)
                    {
                        Position position = new Position(i, j);
                        nombreDePositionLibre.Add(position);
                    }
                        
                }
            }
        }
    }
}
