using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace Task4.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(23);
            queue.Enqueue(3);
            queue.Enqueue(67);
            queue.Enqueue(45);
            queue.Enqueue(9);
            queue.Dequeue();
            queue.Dequeue();
            //Console.WriteLine(queue.Count);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            foreach (int q in queue)
            {
                Console.WriteLine(q);
            }
        }
    }
}
