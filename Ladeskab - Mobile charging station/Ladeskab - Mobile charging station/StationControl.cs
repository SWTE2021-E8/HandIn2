using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab___Mobile_charging_station
{
    public class StationControl
    {
        IRfidReader rfidReader;
        ILogger logger;

        public StationControl(ILogger logger, IRfidReader rfidReader)
        {
            this.logger = logger;
            this.rfidReader = rfidReader;

            rfidReader.RfidDetectedEvent += HandleRfidRecieved;
            rfidReader.GetRfid("1100100101");
        }

        private void HandleRfidRecieved(object sender, RfidDetectedEventArgs e)
        {
            logger.AddToLog("Recieved rfid: " + e.Rfid);
        }
    }
}
