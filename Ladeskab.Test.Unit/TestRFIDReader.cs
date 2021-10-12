﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Test.Unit
{
    class TestRFIDReader
    {
        private RFIDReader uut;
        
        [SetUp]
        public void setup()
        {
            uut = new RFIDReader();

        }

        [TestCase(1)]
        [TestCase(002)]
        [TestCase(12345)]
        [TestCase(1000)]
        public void TestOnRfidRead(int a)
        {
            uut.OnRfidRead(a);
            Assert.AreEqual(uut.lastRfidRecieved,a);
        }

        [Test]
        public void TestwithEvent_called()
        {
            var sub = Substitute.For<IRFIDReader>();
            var EventArg = new RFIDDetectedEventArgs();
            sub.RfidDetectedEvent += Raise.EventWith(new object(), EventArg);
            //started not finished NO TEST


        }


    }
}