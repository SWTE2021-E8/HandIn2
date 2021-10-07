using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class Door : IDoor {
		string DoorStatus = "Open";
		string LockStatus = "unlocked";

	public void OnDoorOpen() {
			System.Console.WriteLine(DoorStatus = "Door Open");
	}

	public void OnDoorClose() {
			System.Console.WriteLine(DoorStatus = "Door Close");
		}
		
	public void LockDoor() {
			System.Console.WriteLine(LockStatus = "Door Locked");
	}

	public void UnlockDoor() {
			System.Console.WriteLine(LockStatus = "Door Unlocked");
	}
    }
}
