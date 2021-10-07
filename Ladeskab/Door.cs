using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class Door : IDoor {

		private IStationControl stationControl;

        public DoorState StateValue { get; private set; }

        public event EventHandler<DoorEventArgs> DoorValueEvent;

        public Door(IStationControl stationControl) {
			this.stationControl = stationControl;
		}
			

	public void OnDoorOpen() {
			//stationControl.Open
			if (StateValue == DoorState.Unlocked){
				StateValue = DoorState.Dooropening;
				OnNewDoorEvent();
				System.Console.WriteLine("Door Open");
			}
	}

	public void OnDoorClose() {
			if (StateValue == DoorState.Dooropening)
			{
				StateValue = DoorState.DoorClosing;
				OnNewDoorEvent();
				System.Console.WriteLine("Door closed");
			}
		}
		s
	public void LockDoor() {
			if (StateValue == DoorState.DoorClosing)
            {
				StateValue = DoorState.Locked;
				System.Console.WriteLine("Door Locked");
			}
	}

	public void UnlockDoor() {
			if (StateValue == DoorState.Locked)
			{
				StateValue = DoorState.Unlocked;
				System.Console.WriteLine("Door Unlocked");
			}
		}
		private void OnNewDoorEvent()
        {
			DoorValueEvent?.Invoke(this, new DoorEventArgs() { Doorstate = this.StateValue });
        }
    }
}
