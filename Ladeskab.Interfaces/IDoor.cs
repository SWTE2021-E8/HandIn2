using System;

namespace Ladeskab.Interfaces
{

    public enum DoorState
    {
        DoorOpen,
        Locked,
        Unlocked
    }

    public class DoorEventArgs : EventArgs
    {
        public DoorState Doorstate { get; set; }

        public DoorEventArgs()
        {
            this.Doorstate = DoorState.Unlocked;
        }

        public DoorEventArgs(DoorState state)
        {
            this.Doorstate = state;
        }
    }

    public interface IDoor
    {

        event EventHandler<DoorEventArgs> DoorValueEvent;
        DoorState StateValue { get; }

        public void LockDoor();
        public void UnlockDoor();
        public void OnDoorOpen();
        public void OnDoorClose();

    }
}
