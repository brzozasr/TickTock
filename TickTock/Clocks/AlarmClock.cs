using System;

namespace TickTock.Clocks
{
    public class AlarmClock : Clock
    {
        public TimeSpan? Alarm { get; private set; }
        protected override string Sound { get; } = "Buzzz";

        public AlarmClock(int hour, int minute, int second) : base(hour, minute, second)
        {
        }

        public void SetAlarm(int hour, int minute, int second)
        {
            Alarm = new TimeSpan(hour, minute, second);
        }

        public TimeSpan HowMuchTimeLeftToSleep()
        {
            var clockTime = new TimeSpan(Hour, Minute, Second);
            TimeSpan result = default;
            if (Alarm.HasValue)
            {
                result = Alarm.Value.Subtract(clockTime);
            }
            return result;
        }

        public bool RunAlarm()
        {
            if (Alarm.HasValue && Alarm.Value.Hours == Hour && Alarm.Value.Minutes == Minute && Alarm.Value.Seconds == Second)
            {
                Alarm = null;
                return true;
            }

            return false;
        }
    }
}