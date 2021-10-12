using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    [TestFixture]
    public class Testdoor
    {
        public Door uut;

        [SetUp]
        public void Setup()
        {
            uut = new Door();
        }


        [Test]
        public void DoorIsUnlockedAtStart()
        {
            Assert.AreEqual(uut.StateValue,DoorState.Unlocked);
        }

        [Test]
        public void DoorGetsLockedAndUnlocked()
        {
            uut.LockDoor();
            Assert.AreEqual(uut.StateValue, DoorState.Locked);

            uut.UnlockDoor();
            Assert.AreEqual(uut.StateValue,DoorState.Unlocked);

        }

        [Test]
        public void DoorClosed()
        {
            uut.OnDoorClose();
            Assert.AreEqual(uut.StateValue, DoorState.Unlocked);
        }

        [Test]
        public void DoorOpen()
        {
            uut.OnDoorOpen();
            Assert.AreEqual(uut.StateValue,DoorState.DoorOpen);
        }
    }

}
