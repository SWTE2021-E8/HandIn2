using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class Door : IDoor {

	public void OnDoorOpen() {
			System.Console.WriteLine("Door Open");
	}

	public void OnDoorClose() {
			System.Console.WriteLine("Door Close");
		}
		
	public void LockDoor() {
			System.Console.WriteLine("Door Locked");
	}

	public void UnlockDoor() {
			System.Console.WriteLine("Door Unlocked");
	}
    }
}
