using System;
using System.Threading;
using TickTock.Clocks;

namespace TickTock
{
    class Program
    {
        static void Main(string[] args)
        {
            var clock1 = new WallClocks(9, 59, 50);
            var clock2 = new WallClocks(9, 59, 50);
            var clock3 = new WallClocks(23, 59, 55);
            
            while (true)
            {
                Console.Clear();
                clock1.ReadTime();
                clock2.ReadTime();
                clock3.ReadTime();
                Thread.Sleep(1000);
            }
        }
    }
}