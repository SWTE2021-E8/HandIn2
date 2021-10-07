using System;
using Ladeskab.Interfaces;

namespace Ladeskab {

    public class Display : IDisplay {
        public void DisplayMsg(string msg) 
        {
            Console.WriteLine("Display: " + msg);
        }
    }
}
