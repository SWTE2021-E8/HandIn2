using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class RFIDReader : IRFIDReader {
        public event EventHandler<RFIDDetectedEventArgs> RfidDetectedEvent;
        private IStationControl stationControl;
        public int lastRfidRecieved { get; private set; }
        public RFIDReader(IStationControl control) 
        {
            stationControl = control;
        }

<<<<<<< Updated upstream
        public void OnRfidRead(int id) {
	}

        public void ScanCard(int id)
        {
            throw new NotImplementedException();
=======
        public void OnRfidRead(int id) 
        {
            HandleRfidDetected(new RFIDDetectedEventArgs { Rfid = id });
            lastRfidRecieved = id;
            
        }

        protected virtual void HandleRfidDetected(RFIDDetectedEventArgs e)
        {
            RfidDetectedEvent?.Invoke(this, e);
>>>>>>> Stashed changes
        }
    }
}