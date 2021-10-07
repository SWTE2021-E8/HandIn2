using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class ChargeControl : IChargeControl {
		IUsbCharger _charger;
		public ChargeControl(IUsbCharger charger)
        {
			_charger = charger;
		}

		public bool Connected() {
			return _charger.Connected;
		}

		public void StartCharge() {
			_charger.StartCharge();
		}

		public void StopCharge() {
			_charger.StopCharge();
		}
		
    }
}
