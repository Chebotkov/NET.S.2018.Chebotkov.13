using System;
using System.Threading;

namespace ClocksTest
{
    class Tester
    {
        static void Main(string[] args)
        {
            Clocks.Timer.Start(0, 0, 20, Write, Write3);
            Clocks.Timer.Start(0, 0, 10, Write2);

            Clocks.Timer.TimeIsOver += Write4;
            Thread.Sleep(11000);
            Clocks.Timer.Start(0, 0, 5);
            Clocks.Timer.TimeIsOver -= Write;
        }

        public static void Write(string message)
        {
            Console.WriteLine(message + " in Write.");
        }

        public static void Write2(string message)
        {
            Console.WriteLine(message + " in Write2.");
        }

        public static void Write3(string message)
        {
            Console.WriteLine(message + " in Write3.");
        }


        public static void Write4(string message)
        {
            Console.WriteLine(message + " in Write4.");
        }
    }
}
