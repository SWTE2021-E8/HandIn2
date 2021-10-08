using System;

namespace Ladeskab.Interfaces
{
    public class RFIDDetectedEventArgs : EventArgs
    {
        public int Rfid { get; set; }
    }

    public interface IRFIDReader
    {
        void OnRfidRead(int id);
        public event EventHandler<RFIDDetectedEventArgs> RfidDetectedEvent;
    }
}
