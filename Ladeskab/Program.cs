using Ladeskab.Interfaces;
using System;

namespace Ladeskab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            IDoor door = new Door();
            IDisplay display = new Display();
            IChargeControl chargeControl = new ChargeControl();
<<<<<<< Updated upstream
            IRFIDReader rfidReader = new RFIDReader();
            IStationControl stationControl = new StationControl(door, chargeControl, display, rfidReader);

=======
            IStationControl stationControl = new StationControl(door, chargeControl, display, rfidReader);
            IRFIDReader rfidReader = new RFIDReader(stationControl);
>>>>>>> Stashed changes

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.OnRfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}

