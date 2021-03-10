namespace TickTock.Clocks
{
    public class WallClocks : Clock
    {
        protected override string Sound { get; } = "Cuckoo";
        public WallClocks(int hour, int minute, int second) : base(hour, minute, second)
        {
        }
        
    }
}