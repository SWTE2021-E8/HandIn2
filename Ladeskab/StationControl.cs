using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class StationControl : IStationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private IDisplay _display;
        private int _oldId;
        private IDoor _door;
        private IRFIDReader _rfidReader;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl(IDoor door, IChargeControl charger, IDisplay display, IRFIDReader rfidReader)
        {
            _state = LadeskabState.Available;
            _door = door;
            _charger = charger;
            _display = display;
            _oldId = 0;
            _rfidReader = rfidReader;

            //Tilføjer rfid handleren til rfid event
            _rfidReader.RfidDetectedEvent += RfidDetected;
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(object sender, RFIDDetectedEventArgs e)
        {
            //Henter RfId'et fra eventet
            int id = e.Rfid;

            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }
                    break;

            }

        }

        void IStationControl.RfidDetected(int id)
        {
            throw new NotImplementedException();
        }

        // Her mangler de andre trigger handlere
        private void DoorOpen(object sender, DoorEventArgs e)
        {
            DoorState doorState = e.Doorstate;

            if(doorState == DoorState.Dooropening)
            {
                _display.DisplayMsg("Tilslut telefon");
            }

        }
        private void DoorClosed(object sender, DoorEventArgs e)
        {
            DoorState doorState = e.Doorstate;

            if (doorState == DoorState.DoorClosing)
            {
                _display.DisplayMsg("Indlæs RFID");
            }
        }
    }
}
