﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab___Mobile_charging_station
{
    public class RfidDetectedEventArgs : EventArgs
    {
        public string Rfid { get; set; }
    }

    class RfidReader : IRfidReader
    {
        string lastRfidRecieved;
        public event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;
        public void GetRfid(string rfidRecieved)
        {
            if (lastRfidRecieved != rfidRecieved)
            {
                OnRfidDetected(new RfidDetectedEventArgs { Rfid = rfidRecieved });
                lastRfidRecieved = rfidRecieved;
            }
        }

        protected private void OnRfidDetected(RfidDetectedEventArgs e)
        {
            RfidDetectedEvent?.Invoke(this, e);
        }
    }

    public interface IRfidReader
    {
        public void GetRfid(string rfidRecieved);
        public event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;
    }
}