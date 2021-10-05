using System;

namespace Ladeskab.Interfaces {
    public interface IRFIDReader {
        public void OnRfidRead(int id);
    }
}
