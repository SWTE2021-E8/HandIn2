using System;
using Ladeskab.Interfaces;

namespace Ladeskab {

    public class ChargeControl : IChargeControl {

	public bool Connected() {
            return true;
        }

	public void StartCharge() {

	}

	public void StopCharge() {

	}

	public void OnDoorOpen() {

	}

	public void OnDoorClose() {

	}
    }
}
