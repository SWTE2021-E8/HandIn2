using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class Door : IDoor {
		string DoorStatus = "Open";
		string LockStatus = "unlocked";

	public void OnDoorOpen() {
			DoorStatus = "Door Open";
	}

	public void OnDoorClose() {
			DoorStatus = "Door Close";
		}

	public void LockDoor() {
			LockStatus = "Door Locked";
	}

	public void UnlockDoor() {
			LockStatus = "Door Unlocked";
	}
    }
}
