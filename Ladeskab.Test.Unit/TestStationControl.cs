﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    class TestStationControl
    {
        public StationControl uut;
        public IDoor Door;
        public IRFIDReader Reader;
        public IChargeControl ChargeControl;
        public IDisplay Display;

        [SetUp]
        public void Setup()
        {
            Door = Substitute.For<IDoor>();
            Reader = Substitute.For<IRFIDReader>();
            ChargeControl = Substitute.For<IChargeControl>();
            Display = Substitute.For<IDisplay>();
            uut = new StationControl(Door,ChargeControl,Display,Reader);
        }

        [Test]
        public void TestInvalidConnection()
        {
            ChargeControl.Connected.Returns(false);
            Reader.RfidDetectedEvent += Raise.EventWith(new object(), new RFIDDetectedEventArgs());
            Display.Received().DisplayMsg("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }

        [Test]
        public void TestValidConnection()
        {
            ChargeControl.Connected.Returns(true);
            var EventArg = new RFIDDetectedEventArgs();
            EventArg.Rfid = 1;
            Reader.RfidDetectedEvent += Raise.EventWith(new object(),EventArg);
            Display.Received().DisplayMsg("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
            Door.Received().LockDoor();
            ChargeControl.Received().StartCharge();
        }

    }
}