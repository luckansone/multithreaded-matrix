using System;
using System.Collections.Generic;
using System.Threading;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(30, 50);
            Console.CursorVisible = false;

            for (int i = 0;i< Console.WindowWidth - 1; i++)
            {
                new Thread(new ParameterizedThreadStart(Chain.Draw)).Start((object)i);
            }
            
        }

    }
}
