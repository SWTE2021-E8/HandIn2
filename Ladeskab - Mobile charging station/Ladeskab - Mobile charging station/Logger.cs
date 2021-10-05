using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab___Mobile_charging_station
{
    public class Logger : ILogger
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

        public Logger()
        {
            log = new List<LogItem>();
        }
        public void AddToLog(string logEntry)
        {
            log.Add(new LogItem(logEntry, DateTime.Now));
        }
        public List<string> GetLog()
        {
            List<string> tmp = new List<string>();
            for (int i = 0; i < log.Count; i++)
            {
                tmp.Add(log[i].text + "....." + log[i].time);
            }
            return tmp;
        }
    }
    
    public interface ILogger
    {
        public void AddToLog(string logEntry);
        public List<string> GetLog();
    }
}
