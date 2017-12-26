using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialisation
            /*string file = "..\\..\\mazeGenerator.txt";
            Labyrinthe maze = new Labyrinthe();
            List<string> liststring = maze.ReadFile(file);
            char[,] matchar = maze.ConvertListStringToMatChar(liststring);
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);


            //Affichage
            maze.Displaychar(matchar);
            Console.WriteLine();


            //Répartion Combatants
            maze.RepartitionCombatants(matchar, positionsLibres);
            maze.Displaychar(matchar);
            Console.WriteLine();

            //Répartion Weapons
            maze.RepartitionWeapon(matchar,positionsLibres);

            maze.Displaychar(matchar);
            Console.WriteLine();
            */

            TestClass test = new TestClass();
            test.TestDeplacement();
            

            Console.ReadKey();
        }


    }
}
