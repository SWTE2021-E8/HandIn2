using System;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class ChargeControl : IChargeControl
    {
        public enum ChargeControlState
        {
            Idle,
            Charging,
            Error,
        }

        IUsbCharger _charger;
        IDisplay _display;
        public bool Connected { get { return _charger.Connected; } }
        public double Current { get; private set; }
        public ChargeControlState chargeControlState { private set; get; }

        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            chargeControlState = ChargeControlState.Idle;
            _charger = charger;
            _display = display;
            _charger.CurrentValueEvent += CurrentChanged;
        }

        public void StartCharge()
        {
            _charger.StartCharge();
        }

        public void StopCharge()
        {
            _charger.StopCharge();
        }

        private void CurrentChanged(object sender, CurrentEventArgs e)
        {
            Current = e.Current;

            if (Current > 0 && Current < 5 && chargeControlState != ChargeControlState.Idle)
            {
                _display.DisplayMsg("Telefonen er fuldt opladet.");
                _charger.StopCharge();
                chargeControlState = ChargeControlState.Idle;
            }
            else if (Current > 5 && Current < 500 && chargeControlState != ChargeControlState.Charging)
            {
                _display.DisplayMsg("Opladning igang.");
                _charger.StartCharge();
                chargeControlState = ChargeControlState.Charging;
            }
            else if (Current > 500 && chargeControlState != ChargeControlState.Error)
            {
                _display.DisplayMsg("Der opstod en fejl under opladning.");
                _charger.StopCharge();
                chargeControlState = ChargeControlState.Error;
            }
        }
    }
}
