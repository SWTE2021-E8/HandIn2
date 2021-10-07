using System;

namespace Ladeskab.Interfaces {
    public interface IStationControl
    {
        void RfidDetected(int id);
        void DoorOpened();
        void DoorClosed();
    }
}
