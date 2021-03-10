using System;

namespace TickTock.Clocks
{
    public class Watch : Clock
    {
        protected override string Sound { get; } = "Tick Tock";
        public readonly ConsoleColor Color;
        
        public Watch(int hour, int minute, int second, ConsoleColor color) : base(hour, minute, second)
        {
            Color = color;
        }
    }
}