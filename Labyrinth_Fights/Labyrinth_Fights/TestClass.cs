using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class TestClass
    {
        public char[,] TestInitialisation(Labyrinthe maze, string file)
        {
            List<string> liststring = maze.ReadFile(file);
            char[,] matchar = maze.ConvertListStringToMatChar(liststring);
            return matchar;
        }

        public void TestDisplays()
        {
            string file = "..\\..\\mazeGenerator.txt";
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, file);
            Cell[,] cells = maze.CharToCell(matchar);
            //maze.DisplayList(liststring);
            //maze.Displaychar(matchar);
            maze.Display(cells);
        }
        public void TestListPositionLibre()
        {
            string file = "..\\..\\mazeJoute.txt";
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, file);
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells); 
            foreach(Position position in positionsLibres)
            {
                Console.WriteLine(position);
            }
        }
        public void TestSpawnCombatant()
        {
            string file = "..\\..\\mazeJoute.txt";
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, file);
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            foreach (Position pose in positionsLibres)
            {
                Console.Write(pose);
            }
            Console.WriteLine();

            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            Position rdmPosFighter1 = positionsLibres[index];
            //Console.WriteLine(rdmPosition);
            FightersFactory factoryFighter = new FightersFactory();
            Fighters fighterStore = new Fighters(factoryFighter);
            Fighter fighter1 = fighterStore.AskForAFighter(rdmPosFighter1);
            positionsLibres.Remove(fighter1.pos);
            maze.Displaychar(matchar);
        }

        public void TestSpawnWeapon()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar,positionsLibres, index);
            maze.Displaychar(matchar);
        }

        public void TestRépartionCombatant()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            maze.RepartitionCombatants(matchar,positionsLibres);
            maze.Displaychar(matchar);
        }

        public void TestRépartionWeapon()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            maze.RepartitionWeapon(matchar, positionsLibres);
            maze.Displaychar(matchar);
        }

        public void TestDeplacement()
        {

            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            Position rdmPosFighter = positionsLibres[index];
            maze.SpawnCombatant(matchar, positionsLibres, index);
            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            Fighter fighter = fighterStore.AskForAFighter(rdmPosFighter);
            matchar[rdmPosFighter.coord_X, rdmPosFighter.coord_Y] = 'X';
            maze.Displaychar(matchar);
            Console.WriteLine();

            while (matchar[fighter.Nord().coord_X, fighter.Nord().coord_Y] != 2 && matchar[fighter.Sud().coord_X, fighter.Sud().coord_Y] != 2 && matchar[fighter.Ouest().coord_X, fighter.Ouest().coord_Y] != 2 && matchar[fighter.Est().coord_X, fighter.Est().coord_Y] != 2)
            {
                Console.WriteLine();
                maze.Deplacement(matchar, fighter);
                maze.Displaychar(matchar);
                Console.ReadKey();
            }
            
            
        }
    }

}
