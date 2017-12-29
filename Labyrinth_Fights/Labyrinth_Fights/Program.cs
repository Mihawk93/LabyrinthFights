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
            string file = "..\\..\\theMaze.txt";
            Labyrinthe maze = new Labyrinthe();
            List<string> liststring = maze.ReadFile(file);
            char[,] matchar = maze.ConvertListStringToMatChar(liststring);
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);


            //Répartion Combatants
            FightersFactory factoryFighter = new FightersFactory();
            Fighters fighterStore = new Fighters(factoryFighter);
            maze.RepartitionCombatants(matchar, positionsLibres, fighterStore);

            maze.fighterList = fighterStore.fightersList;

            //Répartion Weapons
            WeaponsFactory factoryWeapons = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factoryWeapons);
            maze.RepartitionWeapon(matchar,positionsLibres, weaponStore);

            //Stockage des Combatants
            Fighter fighter1 = fighterStore.fightersList[0]; //Bleu
            Fighter fighter2 = fighterStore.fightersList[1]; //Vert
            Fighter fighter3 = fighterStore.fightersList[2]; //Blanc

            

            //Stockage des Armes
            Weapon weapon1 = weaponStore.ListWeapons[0];
            Weapon weapon2 = weaponStore.ListWeapons[1];
            Weapon weapon3 = weaponStore.ListWeapons[2];
            Weapon weapon4 = weaponStore.ListWeapons[3];
            Weapon weapon5 = weaponStore.ListWeapons[4];
            Weapon weapon6 = weaponStore.ListWeapons[5];
            Weapon weapon7 = weaponStore.ListWeapons[6];
            Weapon weapon8 = weaponStore.ListWeapons[7];
            Weapon weapon9 = weaponStore.ListWeapons[8];


            //Boucle du jeu
            while (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] != '2' && matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] != '2' && matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] != '2')
            {
                Weapon weap1 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter1);
                Weapon weap2 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter2);
                Weapon weap3 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter3);

                if (weap1.pos.coord_X != 0 && weap1.pos.coord_Y != 0)
                {
                    fighter1.weapons.Add(weap1);
                    fighter1.Dégats += weap1.dégats;
                    weap1.pos.coord_X = 0;
                    weap1.pos.coord_Y = 0;
                }
                if (weap2.pos.coord_X != 0 && weap2.pos.coord_Y != 0)
                {
                    fighter2.weapons.Add(weap2);
                    fighter2.Dégats += weap2.dégats;
                    weap2.pos.coord_X = 0;
                    weap2.pos.coord_Y = 0;
                }
                if (weap3.pos.coord_X != 0 && weap3.pos.coord_Y != 0)
                {
                    fighter3.weapons.Add(weap3);
                    fighter3.Dégats += weap3.dégats;
                    weap3.pos.coord_X = 0;
                    weap3.pos.coord_Y = 0;
                }

                matchar = CheckFight(matchar, fighterStore, fighter1, fighter2);
                matchar = CheckFight(matchar, fighterStore, fighter1, fighter3);
                if (fighter1.Hp > 0)
                    matchar = maze.Deplacement(matchar, fighter1);

                matchar = CheckFight(matchar, fighterStore, fighter2, fighter1);
                matchar = CheckFight(matchar, fighterStore, fighter2, fighter3);
                if (fighter2.Hp > 0)
                    matchar = maze.Deplacement(matchar, fighter2);


                matchar = CheckFight(matchar, fighterStore, fighter3, fighter1);
                matchar = CheckFight(matchar, fighterStore, fighter3, fighter2);
                if (fighter3.Hp > 0)
                    matchar = maze.Deplacement(matchar, fighter3);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Nombre de fighter: " + fighterStore.fightersList.Count());
                Console.WriteLine("Position du fighter 1 : " + fighter1.pos);
                Console.WriteLine("Arme du fighter 1: " + fighter1.weapons.Count());
                Console.WriteLine("Dégat du fighter1 : " + fighter1.Dégats);
                Console.WriteLine("PV du fighter1 : " + fighter1.Hp);
                Console.ResetColor();
                
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Position du fighter 2 : " + fighter2.pos);
                Console.WriteLine("Arme du fighter 2: " + fighter2.weapons.Count());
                Console.WriteLine("Dégat du fighter2 : " + fighter2.Dégats);
                Console.WriteLine("PV du fighter2 : " + fighter2.Hp);
                Console.ResetColor();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Position du fighter 3 : " + fighter3.pos);
                Console.WriteLine("Arme du fighter 3: " + fighter3.weapons.Count());
                Console.WriteLine("Dégat du fighter3 : " + fighter3.Dégats);
                Console.WriteLine("PV du fighter3 : " + fighter3.Hp);
                Console.ResetColor();

                Console.WriteLine();
                maze.Displaychar(matchar);
                //Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                
                
            }

            //Condition pour finir la partie
            if (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] == '2')
            {
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                fighter1.pos = fighter1.Est();
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.WriteLine("End of the game");
                Console.WriteLine("Combatant 1 a gagné");
            }
            if (matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] == '2')
            {
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = '0';
                fighter2.pos = fighter2.Est();
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.WriteLine("End of the game");
                Console.WriteLine("Combatant 2 a gagné");
            }
            if (matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] == '2')
            {
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = '0';
                fighter3.pos = fighter3.Est();
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.WriteLine("End of the game");
                Console.WriteLine("Combatant 3 a gagné");
            }
            


            Console.ReadKey();
        }

        public static char[,] CheckFight(char[,] matchar, Fighters fighterStore, Fighter fighter1, Fighter fighter2)
        {
            if (fighter2.pos.coord_X == fighter1.pos.coord_X && fighter2.pos.coord_Y == fighter1.pos.coord_Y && fighter2.weapons.Count() != 0 && fighter1.weapons.Count() != 0)
            {
                while (fighter1.Hp > 0 && fighter2.Hp > 0)
                {
                    //maze.Combat(matchar, fighter1, fighter2);
                    fighter1.Hp = fighter1.Hp - fighter2.Dégats;
                    if (fighter1.Hp <= 0)
                    {
                        fighter1.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter1);
                        matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                        Console.WriteLine("Fighter2 a gagné le combat");
                    }
                    if (fighter2.Hp <= 0)
                    {
                        fighter2.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter2);
                        matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = '0';
                        Console.WriteLine("Fighter1 a gagné le combat");
                    }

                    fighter2.Hp = fighter2.Hp - fighter1.Dégats;
                    Console.WriteLine("Fighter1 attaque fighter2");
                    if (fighter1.Hp <= 0)
                    {
                        fighter1.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter1);
                    }
                    if (fighter2.Hp <= 0)
                    {
                        fighter2.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter2);
                    }
                }

            }
            else
            {

                if (fighter1.pos.coord_X == fighter2.pos.coord_X && fighter1.pos.coord_Y == fighter2.pos.coord_Y && fighter1.weapons.Count() != 0)
                {
                    //maze.Combat(matchar, fighter1, fighter2);
                    fighter2.Hp = fighter2.Hp - fighter1.Dégats;
                    Console.WriteLine("Fighter1 attaque fighter2");
                }
                if (fighter2.pos.coord_X == fighter1.pos.coord_X && fighter2.pos.coord_Y == fighter1.pos.coord_Y && fighter2.weapons.Count() != 0)
                {
                    //maze.Combat(matchar, fighter1, fighter2);
                    fighter1.Hp = fighter1.Hp - fighter2.Dégats;
                    Console.WriteLine("Fighter2 attaque fighter1");
                }
            }
            return matchar;
        }

    }
}
