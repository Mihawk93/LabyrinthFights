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
            WeaponsFactory factory = new WeaponsFactory();
            Weapons weaponsStore = new Weapons(factory);
            maze.Displaychar(matchar);
            Console.WriteLine();
            maze.RepartitionWeapon(matchar, positionsLibres,weaponsStore);
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

        public void TestRamasserWeapon()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\theMaze.txt");
            Cell[,] cells = maze.CharToCell(matchar);

            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            maze.SpawnCombatant(matchar, positionsLibres, index);
            Position rdmPosFighter = positionsLibres[index];
            Fighter fighter = fighterStore.AskForAFighter(rdmPosFighter);
            positionsLibres.Remove(fighter.pos);
            maze.Displaychar(matchar);

            WeaponsFactory factory2 = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factory2);
            Random rand2 = new Random();
            int index2 = rand2.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index2);
            Position rdmPosWeapon = positionsLibres[index2-1];
            Weapon weapon = weaponStore.AskForWeapon(rdmPosWeapon);
            positionsLibres.Remove(weapon.pos);
            maze.Displaychar(matchar);
            Console.WriteLine("Position du fighter" + fighter.pos);
            Console.WriteLine("Nombre de fighter" + fighterStore.fightersList.Count());

            while (matchar[fighter.Sud().coord_X, fighter.Sud().coord_Y] != '2')
            {
                
                Weapon weap = maze.ChercheWeapon(weaponStore.ListWeapons, fighter);
                
                if (weap.pos.coord_X!=0 && weap.pos.coord_Y!=0)
                {
                    fighter.weapons.Add(weap);
                    weap.pos.coord_X = 0;
                    weap.pos.coord_Y = 0;
                }
                matchar = maze.Deplacement(matchar, fighter);
                Console.WriteLine("Nombre de fighter" + fighterStore.fightersList.Count());
                maze.Displaychar(matchar);
                Console.Clear();

                Console.WriteLine("Position du fighter" + fighter.pos);
                Console.WriteLine("rdmposweapon:" +rdmPosWeapon);
                Console.WriteLine(weap.pos);
            }
            if (matchar[fighter.Sud().coord_X, fighter.Sud().coord_Y] == '2')
            {
                maze.Displaychar(matchar);
                matchar[fighter.pos.coord_X, fighter.pos.coord_Y] = '0';
                fighter.pos = fighter.Sud();
                matchar[fighter.pos.coord_X, fighter.pos.coord_Y] = 'X';
                Console.ReadKey();
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                Console.Write("Arme du fighter: ");
                Console.WriteLine(fighter.weapons.Count());
                Console.Write("Arme dans la liste: ");
                Console.WriteLine(weaponStore.ListWeapons.Count());
                Console.Write("End of the game");
            }

        }
    }

}
