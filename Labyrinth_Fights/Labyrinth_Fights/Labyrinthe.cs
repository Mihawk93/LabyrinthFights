using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labyrinth_Fights
{

    class Labyrinthe
    {


        public Labyrinthe()
        {
            
        }

        
        public List<Position> PositionLibres(Cell[,] cells)
        {
            List<Position> positionsLibres= new List<Position>();
            for(int i=0; i<cells.GetLength(0);i++)
            {
                for(int j=0;j<cells.GetLength(1);j++)
                {
                    if (cells[i,j].isEmpty)
                    {
                        Position position = new Position(i, j);
                        positionsLibres.Add(position);
                    }
                }
            }
            return positionsLibres;
        }
        /*
        public Position UnePositionLibre(List<Position> positionsLibres, int rnd)
        {
            Position positionLibre;
            return positionLibre = positionsLibres[rnd];
        }*/

        public List<string> ReadFile(string file)
        {
            StreamReader read = null;
            string line;
            string[] champs;
            List<string> champs2 = new List<string>();

            try
            {

                read = new StreamReader(file); //try to open the txt if it exists or try to read if we have the right to
                //throws exception otherwise
                

                while (read.Peek() > 0)
                {
                    //line store the actual line
                    line = read.ReadLine();
                    champs = line.Split(';');

                    for (int i = 0; i < champs.Length; i++)
                    {
                        champs2.Add(champs[i]);
                    }

                }


            }

            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
            }

            finally
            {
                if (read != null)
                {
                    read.Close();

                }
            }

            return champs2;

        }

        public char[,] ConvertListStringToMatChar(List<string> liststr)
        {
            int width = liststr[0].Length;
            int length = liststr.Count;
            char[,] matriceDeChar = new char[length, width];

            for (int i = 0; i < matriceDeChar.GetLength(0); i++)
            {
                for (int j = 0; j < matriceDeChar.GetLength(1); j++)
                {
                    matriceDeChar[i, j] = liststr[i][j];
                }
            }

            return matriceDeChar;


        }

        public Cell[,] CharToCell(char[,] matriceDeChar)
        {
            int width = matriceDeChar.GetLength(1);
            int length = matriceDeChar.GetLength(0);
            Cell[,] matcell = new Cell[length, width];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Position pos = new Position(i, j);
                    switch(matriceDeChar[i,j])
                    {
                        case ('1'):
                            matcell[i, j] = new Cell(pos, false, true, false);
                            break;
                        case ('2'):
                            matcell[i, j] = new Cell(pos, false, false, true);
                            break;
                        case ('0'):
                            matcell[i, j] = new Cell(pos, true, false, false);
                            break;
                        default:
                            matcell[i, j] = new Cell(pos, false, false, false);
                            break;

                    }
                    
                }
            }

            return matcell;
        }

        public void DisplayList (List<string> liste)
        {
            foreach (string str in liste)
            {
                Console.WriteLine(str);
            }
        }

        public void Displaychar(char[,] mat)
        {
            for(int i=0;i<mat.GetLength(0);i++)
            {
                for(int j=0; j<mat.GetLength(1);j++)
                {
                    if (mat[i, j] == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■");
                        Console.ResetColor();
                    }

                    if (mat[i, j] == '2')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("■");
                        Console.ResetColor();
                    }

                    if (mat[i, j] == '0')
                    {
                        Console.Write(" ");
                    }
                    if (mat[i, j] == 'E')
                    {
                        Console.Write("E");
                    }

                    if (mat[i, j] == 'X')
                    {
                        Console.Write("X");
                    }
                    if (mat[i, j] == 'H')
                    {
                        Console.Write("H");
                    }
                    if (mat[i, j] == 'D')
                    {
                        Console.Write("D");
                    }
                    if (mat[i, j] == 'L')
                    {
                        Console.Write("L");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Display(Cell[,] matcell)
        {
            for (int i=0; i<matcell.GetLength(0); i++)
            {
                for(int j=0; j<matcell.GetLength(1); j++)
                {
                    if (matcell[i,j].isWall)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■");
                        Console.ResetColor();
                    }

                    if (matcell[i,j].isExit)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("■");
                        Console.ResetColor();
                    }

                    if(matcell[i,j].isEmpty)
                    {
                        Console.Write(" ");
                    }

                }

                Console.WriteLine();
            }
        }

        public char[,] SpawnCombatant(char[,] mat,List<Position> positionsLibres, int index)
        {
            char[,] matchar = mat;
            Cell[,] cells = CharToCell(matchar);
            Position rdmPosFighter1 = positionsLibres[index];
            FightersFactory factoryFighter = new FightersFactory();
            Fighters fighterStore = new Fighters(factoryFighter);
            Fighter fighter = fighterStore.AskForAFighter(rdmPosFighter1);
            positionsLibres.Remove(fighter.pos);
            matchar[rdmPosFighter1.coord_X, rdmPosFighter1.coord_Y] = 'X';
            return matchar;
        }

        public char[,] SpawnWeapon(char[,] mat, List<Position> positionsLibres, int index)
        {
            char[,] matchar = mat;
            Cell[,] cells = CharToCell(matchar);
            Position rdmPosWeapon = positionsLibres[index];
            WeaponsFactory factoryWeapon = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factoryWeapon);
            Weapon weapon = weaponStore.AskForWeapon(rdmPosWeapon);
            positionsLibres.Remove(weapon.pos);
            if (weapon is Epee)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'E';

            }
            if (weapon is Dague)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'D';

            }
            if (weapon is Hache)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'H';

            }
            if (weapon is Lance)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'L';

            }
            return matchar;
        }

        public char[,] RepartitionCombatants(char[,] mat, List<Position> positionsLibres)
        {
            char[,] matchar = mat;
            Cell[,] cells = CharToCell(matchar);
            double ratio = positionsLibres.Count * 0.01;
            double numOfSpawn = Math.Round(ratio, 0);
            Random rand = new Random();
            int index;
            for (int i=0; i<numOfSpawn;i++)
            {
                index = 0;
                index = rand.Next(positionsLibres.Count);
                SpawnCombatant(matchar,positionsLibres, index);
            }
            return matchar;
            
        }

        public char[,] RepartitionWeapon(char[,] mat, List<Position> positionsLibres)
        {
            char[,] matchar = mat;
            Cell[,] cells = CharToCell(matchar);
            double ratio = positionsLibres.Count * 0.1;
            double numOfSpawn = Math.Round(ratio, 0);
            Random rand = new Random();
            int index = 0;
            for (int i = 0; i < numOfSpawn; i++)
            {
                //index = 0;
                index = rand.Next(positionsLibres.Count);
                SpawnWeapon(matchar, positionsLibres, index);
            }
            return matchar;

        }

        public char[,] Deplacement(char[,] mat, Fighter fighter)
        {
            fighter.Visitees.Add(fighter.pos);
            fighter.Chemin.Push(fighter.pos);
            List<Position> voisinsLibres = new List<Position>();
            Console.Write("positions visitées: ");
            foreach( Position pose in fighter.Visitees)
            {
                
                if(pose==fighter.Nord())
                {
                    fighter.nordVisite = true;
                }
                else
                {
                    fighter.nordVisite = false;
                    if (pose == fighter.Sud())
                    {
                        fighter.sudVisite = true;
                    }
                    else
                    {
                        fighter.sudVisite = false;
                        if (pose == fighter.Ouest())
                        {
                            fighter.ouestVisite = true;
                        }
                        else
                        {
                            fighter.ouestVisite = false;
                            if (pose == fighter.Est())
                            {
                                fighter.estVisite = true;
                            }
                            else
                            {
                                fighter.ouestVisite = false;
                            }
                        }
                        
                    }
                    
                }
               
                Console.Write(pose);
            }
            if(mat[fighter.Nord().coord_X,fighter.Nord().coord_Y] == '0' && fighter.nordVisite == false)
            {
                voisinsLibres.Add(fighter.Nord());
            }
            if (mat[fighter.Sud().coord_X, fighter.Sud().coord_Y] == '0' && fighter.sudVisite == false)
            {
                voisinsLibres.Add(fighter.Sud());
            }
            if (mat[fighter.Ouest().coord_X, fighter.Ouest().coord_Y] == '0' && fighter.ouestVisite == false)
            {
                voisinsLibres.Add(fighter.Ouest());
            }
            if (mat[fighter.Est().coord_X, fighter.Est().coord_Y] == '0' && fighter.estVisite == false)
            {
                voisinsLibres.Add(fighter.Est());
            }

            Random rand = new Random();
            int index = rand.Next(voisinsLibres.Count);
            Console.WriteLine();
            Console.Write("voisins libres: ");
            foreach (Position pose in voisinsLibres)
            {
                
                Console.Write(pose);
            }
            Console.WriteLine("random: " + index);
            mat[fighter.pos.coord_X, fighter.pos.coord_Y] = '0';
            fighter.pos = voisinsLibres[index];
            mat[fighter.pos.coord_X, fighter.pos.coord_Y] = 'X';
            return mat;
        }

    }
}
