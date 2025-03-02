using System;

namespace SimpleMazeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //This thing took more than 12 hours and i still dont know how to code...
            //It took the internet, Youtube, Github, StackOverflow, Classmates, Brain and maybe a bit of Artifical Inteligence.

            int vyska = 21;
            int sirka = 69;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            // zed
            int[,] blud = new int[vyska, sirka];
            for (int i = 0; i < vyska; i++)
            {
                for (int j = 0; j < sirka; j++)
                {
                    blud[i, j] = 0; 
                }
            }

            // Generovani samotneho bludiste
            GenerateBlud(blud, 1, 1);

            int playerX = 1;
            int playerY = 1;
            int exitX = vyska - 2;
            int exitY = sirka - 2;

            blud[exitX, exitY] = 1;

            int steps = 0;

            // Main game loop
            while (true)
            {
                Console.Clear();
                PrintMaze(blud, playerX, playerY, exitX, exitY);

                //X
                if (playerX == exitX && playerY == exitY)
                {
                    Console.WriteLine("The end...");
                    Console.WriteLine("steps take: " + steps);
                    break;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                
                if (key.Key == ConsoleKey.W) 
                {
                    if (playerX - 1 >= 0 && blud[playerX - 1, playerY] == 1)
                    {
                        playerX--; 
                        steps++;
                    }
                }
                else if (key.Key == ConsoleKey.S) 
                {
                    if (playerX + 1 < vyska && blud[playerX + 1, playerY] == 1)
                    {
                        playerX++; 
                        steps++;
                    }
                }
                else if (key.Key == ConsoleKey.A) 
                {
                    if (playerY - 1 >= 0 && blud[playerX, playerY - 1] == 1)
                    {
                        playerY--; 
                        steps++;
                    }
                }

                else if (key.Key == ConsoleKey.D) 
                {
                    if (playerY + 1 < sirka && blud[playerX, playerY + 1] == 1)
                    {
                        playerY++; 
                        steps++;
                    }
                }
            }

           //StackOverflow
            static void GenerateBlud(int[,] blud, int x, int y)
            {
                Random random = new Random();
                int[] dx = { 0, 0, -1, 1 }; 
                int[] dy = { -1, 1, 0, 0 };

                blud[x, y] = 1; 


                int[] directions = { 0, 1, 2, 3 };
                Shuffle(directions); 

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[directions[i]] * 2;
                    int ny = y + dy[directions[i]] * 2;

                    if (nx > 0 && ny > 0 && nx < blud.GetLength(0) && ny < blud.GetLength(1) && blud[nx, ny] == 0)
                    {
                        blud[nx, ny] = 1; 
                        blud[x + dx[directions[i]], y + dy[directions[i]]] = 1; 
                        GenerateBlud(blud, nx, ny); 
                    }
                }
            }

            static void Shuffle(int[] array)
            {
                Random rand = new Random();
                for (int i = array.Length - 1; i > 0; i--)
                {
                    int j = rand.Next(0, i);
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            static void PrintMaze(int[,] blud, int playerX, int playerY, int exitX, int exitY)
            {
                for (int i = 0; i < blud.GetLength(0); i++)
                {
                    for (int j = 0; j < blud.GetLength(1); j++)
                    {
                        if (i == playerX && j == playerY)
                        {
                            Console.Write("0"); 
                        }
                        else if (i == exitX && j == exitY)
                        {
                            Console.Write("X"); 
                        }
                        else if (blud[i, j] == 0)
                        {
                            Console.Write("#"); 
                        }
                        else
                        {
                            Console.Write("."); 
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
