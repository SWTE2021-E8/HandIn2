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

		/* Jeg kan sku ik se hvad de skal bruges til...
		 * Charge control er jo kun afhængig af om der er 
		 * en telefon forbundet eller ej, hvilket den får af connected 
		 */

		public void OnDoorOpen() {

		}

		public void OnDoorClose() {

		}
		
    }
}
