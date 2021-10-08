using System;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door : IDoor
    {

        private IStationControl stationControl;

        public DoorState StateValue { get; private set; }

        public event EventHandler<DoorEventArgs> DoorValueEvent;

        public Door()
        {
            StateValue = DoorState.Unlocked;
        }

        public void OnDoorOpen()
        {
            //stationControl.Open
            if (StateValue == DoorState.Unlocked)
            {
                StateValue = DoorState.DoorOpen;
                OnNewDoorEvent();
            }
        }

        public void OnDoorClose()
        {
            if (StateValue == DoorState.DoorOpen)
            {
                StateValue = DoorState.Unlocked;
                OnNewDoorEvent();
            }
        }

        public void LockDoor()
        {
            if (StateValue == DoorState.Unlocked)
            {
                StateValue = DoorState.Locked;
            }
        }

        public void UnlockDoor()
        {
            if (StateValue == DoorState.Locked)
            {
                StateValue = DoorState.Unlocked;
            }
        }

        private void OnNewDoorEvent()
        {
            DoorValueEvent?.Invoke(this, new DoorEventArgs() { Doorstate = this.StateValue });
        }
    }
}
