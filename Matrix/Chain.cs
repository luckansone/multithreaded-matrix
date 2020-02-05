using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Matrix
{
    static class Chain
    {
        static string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private static object locker = new object();
        static Random Random = new Random();



        public static void Draw(object x)
        {
            int Length = Random.Next(5, 10);
            int Y = Random.Next(0, Console.WindowHeight - 2);
            int X = (int)x;
            int currentY = 0, chainCount = 0;
            

            for (int i = 0; i < Length; i++)
            {
                lock (locker)
                {
                    SetPosition(X, ref Y, ref currentY);
                    SetColor(ref chainCount);

                    if(chainCount == Length)
                    {
                        chainCount = 0;
                    }

                    CutChain(Y, X, ref i, Length);
                    Thread.Sleep(0);
                }
            }
           
        }


        private static void CutChain(int y, int x, ref int i, int Length)
        {
            if (i == Length - 1)
            {
                if (y >= Length)
                {
                    Console.SetCursorPosition(x, y - Length);
                }
                else
                {
                    Console.SetCursorPosition(x, Console.WindowHeight - Length + y);
                }
                Console.Write(' ');
                i--;
            }
        }
        public static void SetPosition(int x, ref int y, ref int currentY)
        {
            if (y == Console.WindowHeight - 1)
            {
                y = 0;
                currentY = 1;
                Console.SetCursorPosition(x, y);
            }
            else
            {
                currentY = y + 1;
                Console.SetCursorPosition(x, y++);
            }
        }
        public static char GetRandomChar()
        {
            int index = Random.Next(0, symbols.Length - 1);
            return symbols[index];
        }

        private static void SetColor(ref int chainCount)
        {
                if (chainCount == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(GetRandomChar());
                    chainCount++;
                }
                else
                {
                    if (chainCount == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(GetRandomChar());
                        chainCount++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(GetRandomChar());
                        chainCount++;
                    }
                }
            

        }
    }
}


