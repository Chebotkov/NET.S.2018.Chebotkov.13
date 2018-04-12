using System;

namespace ClocksTest
{
    class Tester
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Clocks.Timer timer = new Clocks.Timer();
            timer.TimeIsOver += Write;
            timer.TimeIsOver += Write2;
            timer.Start(0, 0, 10);
            timer.Start(0, 0, 5);

        }

        public static void Write(string message)
        {
            Console.WriteLine(message + " in Write.");
        }

        public static void Write2(string message)
        {
            Console.WriteLine(message + " in Write2.");
        }
    }
}
