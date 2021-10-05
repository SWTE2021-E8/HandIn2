using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab___Mobile_charging_station
{
    public class DoorStateChangedEventArgs : EventArgs
    {
        public bool State { get; set; }
    }

    public class Door : IDoor
    {
        bool currentState;
        bool isLocked;
        public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;

        public void SetDoorState(bool state)
        {
            if(state != currentState)
            {
                OnDoorOpen(new DoorStateChangedEventArgs { State = state });
                currentState = state;
            }
        }
        
        protected virtual void OnDoorOpen(DoorStateChangedEventArgs e)
        {
            DoorStateChangedEvent?.Invoke(this, e);
        }
    }

    public interface IDoor
    {
        event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;
    }
}
