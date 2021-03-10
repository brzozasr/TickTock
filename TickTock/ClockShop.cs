using System;
using System.Collections.Generic;
using TickTock.Clocks;
using TickTock.Utilities;

namespace TickTock
{
    public class ClockShop
    {
        private Dictionary<int, Clock> _clocks;

        public ClockShop()
        {
            _clocks = new Dictionary<int, Clock>();
        }

        public Dictionary<int, Clock> GenerateClocks(int noOfClocks)
        {
            ConsoleColor[] color = new ConsoleColor[]
            {
                ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.Green,
                ConsoleColor.DarkRed
            };
            
            int randColor1 = Utils.Random.Next(0, 6);

            while (_clocks.Count < noOfClocks)
            {
                int randClock = Utils.Random.Next(0, 4);
                int randHour = Utils.Random.Next(0, 24);
                int randMinute = Utils.Random.Next(0, 59);
                int randSecond = Utils.Random.Next(0, 59);
                int randColor = Utils.Random.Next(0, 6);

                switch (randClock)
                {
                    case 0:
                        var wallClocks = new WallClocks(randHour, randMinute, randSecond);
                        _clocks.Add(wallClocks.GetHashCode(), wallClocks);
                        break;
                    case 1:
                        var watch = new Watch(randHour, randMinute, randSecond, color[randColor]);
                        _clocks.Add(watch.GetHashCode(), watch);
                        break;
                    case 2:
                        var alarmClock = new AlarmClock(randHour, randMinute, randSecond);
                        _clocks.Add(alarmClock.GetHashCode(), alarmClock);
                        break;
                    case 3:
                        var bigBen = BigBen.GetInstance(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Minute);
                        if (!_clocks.ContainsKey(bigBen.GetHashCode()))
                        {
                            _clocks.Add(bigBen.GetHashCode(), bigBen);
                        }
                        break;
                    default:
                        throw new ArgumentException("There is no such a clock!");
                }
            }
            
            var wallClocks1 = new WallClocks(15, 59, 45);
            var watch1 = new Watch(15, 59, 45, color[randColor1]);
            var alarmClock1 = new AlarmClock(15, 59, 45);
            _clocks.Add(wallClocks1.GetHashCode(), wallClocks1);
            _clocks.Add(watch1.GetHashCode(), watch1);
            _clocks.Add(alarmClock1.GetHashCode(), alarmClock1);
            return _clocks;
        }
    }
}