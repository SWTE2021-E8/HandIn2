
using System;

namespace Ladeskab___Mobile_charging_station
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            IRfidReader rfidReader = new RfidReader();

            StationControl stationControl = new StationControl(logger, rfidReader);
            var tmp = logger.GetLog();

            Console.WriteLine(tmp[0]);
        }
    }

}
