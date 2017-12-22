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
        //attributs


        static List<Position> nombreDePositionLibre;
        static int[,] map;


        public Labyrinthe()
        {
            
        }


        /*
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
        */


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
                    Console.Write(mat[i, j]);
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


    }
}
