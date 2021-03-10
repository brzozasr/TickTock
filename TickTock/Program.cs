using System;
using System.Threading;
using TickTock.Clocks;

namespace TickTock
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockShop shop = new ClockShop();
            var clocks= shop.GenerateClocks(15);

            int i = 1;
            while (true)
            {
                Console.Clear();
                foreach (var (hash, clock) in clocks)
                {
                    clock.ReadTime(i);
                    i++;
                }
                Thread.Sleep(1000);
                i = 1;
            }
        }
    }
}