using System;

namespace Ladeskab.Interfaces {

    public enum DoorState
    {
        Dooropening,
        DoorClosing,
        Locked,
        Unlocked
    }
    public class DoorEventArgs : EventArgs
    {
        public DoorState Doorstate { get; set; }
    }
    public interface IDoor {

        event EventHandler<DoorEventArgs> DoorValueEvent;
        DoorState StateValue { get; }

        public void LockDoor();
        public void UnlockDoor();
        public void OnDoorOpen();
        public void OnDoorClose();

    }
}
