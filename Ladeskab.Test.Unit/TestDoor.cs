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
            Assert.AreEqual(uut.StateValue, DoorState.Unlocked);
        }

        [Test]
        public void DoorRemainsUnlockedWhenUnlocked()
        {
            uut.UnlockDoor();
            Assert.AreEqual(uut.StateValue, DoorState.Unlocked);
        }

        [Test]
        public void DoorGetsLockedAndUnlocked()
        {
            uut.LockDoor();
            Assert.AreEqual(uut.StateValue, DoorState.Locked);

            uut.UnlockDoor();
            Assert.AreEqual(uut.StateValue, DoorState.Unlocked);

        }

        [Test]
        public void Door_Try_Close_When_Unlocked()
        {
            uut.OnDoorClose();
            Assert.AreEqual(uut.StateValue, DoorState.Unlocked);
        }

        [Test]
        public void Door_Close_When_Opened()
        {
            uut.OnDoorOpen();
            Assert.AreEqual(uut.StateValue, DoorState.DoorOpen);
            uut.OnDoorClose();
            Assert.AreEqual(uut.StateValue, DoorState.Unlocked);
        }

        [Test]
        public void DoorOpen()
        {
            uut.OnDoorOpen();
            Assert.AreEqual(uut.StateValue, DoorState.DoorOpen);
        }

        [Test]
        public void DoorEventArgs_Default_Constructor()
        {
            DoorEventArgs args = new DoorEventArgs();
            Assert.AreEqual(DoorState.Unlocked, args.Doorstate);
        }

        [Test]
        public void DoorEventArgs_Parameterized_Constructor()
        {
            DoorEventArgs args = new DoorEventArgs(DoorState.DoorOpen);
            Assert.AreEqual(DoorState.DoorOpen, args.Doorstate);
        }

        [Test]
        public void DoorEventArgs_Test_Set()
        {
            DoorEventArgs args = new DoorEventArgs();
            args.Doorstate = DoorState.Locked;
            Assert.AreEqual(DoorState.Locked, args.Doorstate);
        }

    }

}
