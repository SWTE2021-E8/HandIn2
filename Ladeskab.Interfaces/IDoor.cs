using System;

namespace Ladeskab.Interfaces {
    public interface IDoor {
        public void LockDoor();
        public void UnlockDoor();
        public void OnDoorOpen();
        public void OnDoorClose();
    }
}
