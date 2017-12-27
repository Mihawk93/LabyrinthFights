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
            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            maze.RepartitionCombatants(matchar,positionsLibres,fighterStore);
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
            char[,] matchar = TestInitialisation(maze, "..\\..\\theMaze.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.RepartitionCombatants(matchar, positionsLibres, fighterStore);
            maze.Displaychar(matchar);
            Console.WriteLine();

            Fighter fighter1 = fighterStore.fightersList[0];
            Fighter fighter2 = fighterStore.fightersList[1];
            Fighter fighter3 = fighterStore.fightersList[2];
            maze.Displaychar(matchar);
            Console.WriteLine();
            while (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] != '2' && matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] != '2' && matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] != '2')
            {
                matchar = maze.Deplacement(matchar, fighter1);
                matchar = maze.Deplacement(matchar, fighter2);
                matchar = maze.Deplacement(matchar, fighter3);
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
            }
            if (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] == '2')
            {
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                fighter1.pos = fighter1.Est();
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.Write("End of the game");
            }
            if (matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] == '2')
            {
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = '0';
                fighter2.pos = fighter2.Est();
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.Write("End of the game");
            }
            if (matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] == '2')
            {
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = '0';
                fighter3.pos = fighter3.Est();
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.Write("End of the game");
            }


        }
    }

}
