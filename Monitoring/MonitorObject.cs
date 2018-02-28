using System;
using System.Collections.Generic;
using System.Text;

namespace Monitoring
{
    public class MonitorObject
    {
        //Public
        public TimeSpan TimeSpan { get; set; } //The time from start to finish before the task is finished.
        public string Name { get; set; } //E.g. ClientLoginResponseTime.

        //Private
        DateTime StartTime;
        DateTime EndTime;
        bool TimerStarted;

        /*
         * Monitoring should be asynchronous.
         * Should be stored in a database.
         * 
         */
        public MonitorObject()
        {}

        public void StartMonitoring()
        {
            StartTime = DateTime.Now;
            TimerStarted = true;
        }
        public void StopMonitoring()
        {
            if (!TimerStarted)
                return;

            EndTime = DateTime.Now;
            CalculateTimeSpan();
            TimerStarted = false;
        }

        void CalculateTimeSpan()
        {
            TimeSpan timeSpanStart = new TimeSpan(StartTime.Day, StartTime.Hour, StartTime.Minute, StartTime.Second, StartTime.Millisecond);
            TimeSpan timeSpanEnd = new TimeSpan(EndTime.Day, EndTime.Hour, EndTime.Minute, EndTime.Second, EndTime.Millisecond);
            TimeSpan = timeSpanEnd.Subtract(timeSpanStart);
        }

        /*
        // Use TimeSpan constructor to specify:
        // ... Days, hours, minutes, seconds, milliseconds.
        // ... The TimeSpan returned has those values.
        TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);
        Console.WriteLine(span);
         */
    }
}
