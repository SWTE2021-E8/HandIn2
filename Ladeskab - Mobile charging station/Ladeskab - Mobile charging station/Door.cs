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
    public class LockStateChangedEventArgs : EventArgs
    {
        public bool State { get; set; }
    }

    public class Door : IDoor
    {
        bool currentState;
        bool isLocked;
        public event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;
        public event EventHandler<LockStateChangedEventArgs> LockStateChangedEvent;

        public void SetDoorState(bool state)
        {
            if (!isLocked)
            {
                if (state != currentState)
                {
                    OnDoorStateChanged(new DoorStateChangedEventArgs { State = state });
                    currentState = state;
                }
            }
            else throw new InvalidOperationException("Door is currently locked, unlock it first");
        }
        public void SetLockState(bool state)
        {
            if (state != isLocked)
            {
                OnLockStateChanged(new LockStateChangedEventArgs { State = state });
                isLocked = state;
            }
            else throw new InvalidOperationException("Lock is already set to given state");
        }
        
        protected virtual void OnDoorStateChanged(DoorStateChangedEventArgs e)
        {
            DoorStateChangedEvent?.Invoke(this, e);
        }
        protected virtual void OnLockStateChanged(LockStateChangedEventArgs e)
        {
            LockStateChangedEvent?.Invoke(this, e);
        }
    }

    public interface IDoor
    {
        event EventHandler<DoorStateChangedEventArgs> DoorStateChangedEvent;
        event EventHandler<LockStateChangedEventArgs> LockStateChangedEvent;
    }
}
