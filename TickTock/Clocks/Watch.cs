using System;

namespace TickTock.Clocks
{
    public class Watch : Clock
    {
        public readonly ConsoleColor Color;
        protected override string Sound { get; } = "Tick Tock";

        public Watch(int hour, int minute, int second, ConsoleColor color) : base(hour, minute, second)
        {
            Color = color;
        }
    }
}