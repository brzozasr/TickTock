using System;
using System.Threading;
using TickTock.Utilities;

namespace TickTock.Clocks
{
    public abstract class Clock
    {
        protected int Hour { get; private set; }
        protected int Minute { get; private set; }
        protected int Second { get; private set; }

        private int Millisecond { get; set; }
        protected abstract string Sound { get; }

        private readonly int _delay = Utils.Random.Next(-100000, 100001); // 10 millisecond

        protected Clock(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public void SetTime(int hour, int minute, int second)
        {
            var h = TimeSpan.FromHours(hour);
            var m = TimeSpan.FromMinutes(minute);
            var s = TimeSpan.FromSeconds(second);

            Hour = h.Hours;
            Minute = m.Minutes;
            Second = s.Seconds;
        }

        public void ReadTime(int no)
        {
            UpdateTimeFromTicks();

            var h = TimeSpan.FromHours(Hour);
            var m = TimeSpan.FromMinutes(Minute);
            var s = TimeSpan.FromSeconds(Second);
            TimeSpan time = h.Add(m).Add(s);

            string sound = null;
            if (m.Minutes == 0 && s.Seconds == 0)
            {
                sound = $", sound: {Sound}";
            }
            else
            {
                sound = null;
            }

            var clockName = $"{GetType().Name}:";
            var newNo = $"{no}.";
            if (this is Watch watch)
            {
                Console.ForegroundColor = watch.Color;
                Console.WriteLine($"{newNo, -4}{clockName, -15} {time}{sound}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{newNo, -4}{clockName, -15} {time}{sound}");
            }
        }

        private void UpdateTimeFromTicks()
        {
            DateTime currentNow = DateTime.Now;
            DateTime setClockTime = new DateTime(currentNow.Year, currentNow.Month, currentNow.Day, Hour, Minute,
                Second, Millisecond);
            long ticksClock = setClockTime.Ticks;
            
            long oneTickSecond = 10000000;

            TimeSpan ts = TimeSpan.FromTicks(ticksClock + oneTickSecond + _delay);

            var hours = ts.Hours;
            var minutes = ts.Minutes;
            var seconds = ts.Seconds;
            var milliseconds = ts.Milliseconds;

            Hour = hours;
            Minute = minutes;
            Second = seconds;
            Millisecond = milliseconds;
        }

        // 1 Tick per second = 10 000 000
        // 1 Tick per millisecond = 10 000
    }
}