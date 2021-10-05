using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab___Mobile_charging_station
{
    class Logger
    {
        public class LogItem
        {
            public string text { get; private set; }
            public DateTime time { get; private set; }
            public LogItem(string s, DateTime d)
            {
                time = d;
                text = s;
            }
        }
        public List<LogItem> log { get; private set; }

        public void AddToLog(string logEntry)
        {
            log.Add(new LogItem(logEntry, DateTime.Now));
        }
    }
}
