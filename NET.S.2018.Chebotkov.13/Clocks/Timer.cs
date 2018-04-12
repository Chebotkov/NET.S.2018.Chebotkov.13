using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clocks
{
    public class Timer
    {
        public delegate void TimeHandler(string message);
        public event TimeHandler TimeIsOver;
        public Timer()
        {

        }

        public void Start(int hours, int minutes, int seconds)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Ticker));
            thread.Start(new Time(hours, minutes, seconds));
        }

        private void Ticker(object time)
        {
            Time t = (Time)time;
            int s = 0, m = 0, h = 0;
            while (true)
            {
                if (h >= t.Hours)
                {
                    if (m >= t.Minutes)
                    {
                        if (s >= t.Seconds)
                        {
                            if (TimeIsOver is null)
                            {
                                throw new ArgumentNullException("{0} is null", nameof(TimeIsOver));
                            }

                            TimeIsOver("Time is over.");
                            return;
                        }
                    }
                }

                s++;
                if (s == 60)
                {
                    m++;
                    s = 0;
                }
                if (m == 60)
                {
                    h++;
                    m = 0;
                }
                Thread.Sleep(1000);
            }
        }

        private class Time
        {
            private int hours;
            private int minutes;
            private int seconds;

            public Time(int hours, int minutes, int seconds)
            {
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
            }

            public int Hours
            {
                get
                {
                    return hours;
                }
            }

            public int Minutes
            {
                get
                {
                    return minutes;
                }
            }

            public int Seconds
            {
                get
                {
                    return seconds;
                }
            }
        }
    }
}
