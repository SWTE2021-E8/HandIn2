using System;

namespace Ladeskab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            Door door = new Door();
            Display display = new Display();
            UsbChargerSimulator charger = new UsbChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(charger, display);
            RFIDReader rfidReader = new RFIDReader();
            //StationControl stationControl = new StationControl(door, chargeControl, display, rfidReader);


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