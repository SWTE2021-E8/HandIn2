using System;

namespace Ladeskab.Interfaces {
    public interface IRFIDReader {
        void OnRfidRead(int id);
        void ScanCard(int id);
    }
}
