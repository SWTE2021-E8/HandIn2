using System;

namespace Ladeskab.Interfaces {

    public interface IChargeControl {
        public bool Connected();
        public void StartCharge();
        public void StopCharge();
        public void OnDoorOpen();
        public void OnDoorClose();
    }
}
