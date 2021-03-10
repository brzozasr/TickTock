using System;

namespace TickTock.Clocks
{
    public class AlarmClock : Clock
    {
        protected override string Sound { get; } = "Buzzz";
        protected TimeSpan? Alarm;
        
        public AlarmClock(int hour, int minute, int second) : base(hour, minute, second)
        {
        }

        public void SetAlarm(int hour, int minute, int second)
        {
            Alarm = new TimeSpan(hour, minute, second);
        }

        public TimeSpan HowMuchTimeLeftToSleep()
        {
            var timeNow = DateTime.Now.TimeOfDay;
            TimeSpan result = default;
            if (Alarm.HasValue)
            {
                result = Alarm.Value.Subtract(timeNow);
            }
            return result;
        }
    }
}