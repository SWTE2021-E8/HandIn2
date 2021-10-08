using System;

namespace Ladeskab.Interfaces
{

    public interface IChargeControl
    {
        bool Connected { get; }
        public void StartCharge();
        public void StopCharge();
    }
}
