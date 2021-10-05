using System;
using Ladeskab.Interfaces;

namespace Ladeskab {
    public class RFIDReader : IRFIDReader {
        private IStationControl stationControl;

	public RFIDReader(IStationControl control) {
            stationControl = control;
        }

        public void OnRfidRead(int id) {
	}
    }
}
