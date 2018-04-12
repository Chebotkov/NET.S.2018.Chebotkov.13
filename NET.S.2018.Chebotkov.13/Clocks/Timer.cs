using System;
using System.Threading;

namespace Clocks
{
    /// <summary>
    /// COntains methods for working with time.
    /// </summary>
    public class Timer
    {
        public delegate void TimeHandler(string message);
        public static event TimeHandler TimeIsOver;

        #region ctor.
        /// <summary>
        /// Initializes a new instance of <see cref="Timer"/>
        /// </summary>
        public Timer()
        {

        }

        #endregion

        #region Public methods
        /// <summary>
        /// Counts the time.
        /// </summary>
        /// <param name="hours">Hours.</param>
        /// <param name="minutes">Minutes.</param>
        /// <param name="seconds">Seconds.</param>
        /// <param name="timeHandlers">Timehandlers.</param>
        public static void Start(int hours, int minutes, int seconds, params TimeHandler[] timeHandlers)
        {
            foreach (TimeHandler t in timeHandlers)
            {
                TimeIsOver += t;
            }

            Thread thread = new Thread(new ParameterizedThreadStart(Ticker));
            thread.Start(new Time(hours, minutes, seconds));
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Counts the time.
        /// </summary>
        /// <param name="time">Setted time.</param>
        private static void Ticker(object time)
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
        #endregion

        #region Class Time
        /// <summary>
        /// Time representation.
        /// </summary>
        private class Time
        {
            private int hours;
            private int minutes;
            private int seconds;

            /// <summary>
            /// Initializes a new instance of <see cref="Time"/>
            /// </summary>
            /// <param name="hours">Hours.</param>
            /// <param name="minutes">Minutes.</param>
            /// <param name="seconds">Seconds.</param>
            public Time(int hours, int minutes, int seconds)
            {
                this.hours = hours;
                this.minutes = minutes;
                this.seconds = seconds;
            }

            /// <summary>
            /// Gets Hours.
            /// </summary>
            public int Hours
            {
                get
                {
                    return hours;
                }
            }

            /// <summary>
            /// Gets minutes.
            /// </summary>
            public int Minutes
            {
                get
                {
                    return minutes;
                }
            }
            
            /// <summary>
            /// Gets seconds.
            /// </summary>
            public int Seconds
            {
                get
                {
                    return seconds;
                }
            }
        }
        #endregion
    }
}
