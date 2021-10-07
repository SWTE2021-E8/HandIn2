using System;

namespace Ladeskab.Interfaces {
    public class RFIDDetectedEventArgs : EventArgs
    {
        public int Rfid { get; set; }
    }
    public interface IRFIDReader {
<<<<<<< Updated upstream
        void OnRfidRead(int id);
        void ScanCard(int id);
=======
        public event EventHandler<RFIDDetectedEventArgs> RfidDetectedEvent;
        public void OnRfidRead(int id);
>>>>>>> Stashed changes
    }
}
