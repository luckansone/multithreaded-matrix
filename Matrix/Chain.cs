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
            int Y = 0;
            int X = (int)x;
            int currentY = 0;

           
            for (int i = 0; i < Length; i++)
            {
                    lock (locker)
                    {
                        SetPosition(X, ref Y, ref currentY);

                        SetColor(X, currentY, i, Length);

                        CutChain(Y, X, ref i, Length);
                    }
                if (currentY == 10)
                {
                    new Thread(new ParameterizedThreadStart(Chain.Draw)).Start(x);
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

        private static void SetColor(int X, int currentY, int i, int Length)
        {
           
           Console.ForegroundColor = ConsoleColor.White;
           Console.WriteLine(GetRandomChar());

            if (currentY > 2 && i>=2)
            {
              
                Console.SetCursorPosition(X, currentY - 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(GetRandomChar());

                Console.SetCursorPosition(X, currentY - 3);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(GetRandomChar());
            }

        }
    }
}


