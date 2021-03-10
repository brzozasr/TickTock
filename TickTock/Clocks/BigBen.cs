using System;

namespace TickTock.Clocks
{
    public sealed class BigBen : Clock
    {
        protected override string Sound { get; } = "Big Ben";
        private static Lazy<BigBen> _bigBen;
        private static readonly object Lock = new object();

        private BigBen(int hour, int minute, int second) : base(hour, minute, second)
        {
        }

        public static BigBen GetInstance(int hour, int minute, int second)
        {
            if (_bigBen == null)
            {
                lock (Lock)
                {
                    if (_bigBen == null)
                    {
                        _bigBen = new Lazy<BigBen>(() => new BigBen(hour, minute, second));
                    }
                }
            }
            return _bigBen.Value;
        }
    }
}