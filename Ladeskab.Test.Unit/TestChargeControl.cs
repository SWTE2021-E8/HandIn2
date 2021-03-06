using Ladeskab.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using System.Windows.Input;

namespace Ladeskab.Test.Unit
{
    class TestChargeControl
    {
        [TestFixture]
        public class TestUsbChargerSimulator
        {
            ChargeControl _uut;
            IDisplay display;
            IUsbCharger charger;

            [SetUp]
            public void Setup()
            {
                display = Substitute.For<Display>();
                charger = Substitute.For<IUsbCharger>();
                _uut = new ChargeControl(charger, display);
            }

            [Test]
            public void ChargeControl_IsConnected_returnTrue()
            {
                charger.Connected.Returns(true);
                Assert.IsTrue(_uut.Connected);
            }

            [Test]
            public void ChargeControl_IsConnected_returnFalse()
            {
                charger.Connected.Returns(false);
                Assert.IsFalse(_uut.Connected);
            }

            [Test]
            public void ChargeControl_Current_ReturnValue()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 100;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(100, _uut.Current);
            }

            [Test]
            public void ChargeControl_ChargeControlState_ReturnIdle_1mA()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 1;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Idle, _uut.chargeControlState);
            }

            [Test]
            public void ChargeControl_ChargeControlState_ReturnIdle_5mA()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 5;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Idle, _uut.chargeControlState);
            }

            [Test]
            public void ChargeControl_ChargeControlState_ReturnCharging_6mA()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 6;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Charging, _uut.chargeControlState);
            }

            [Test]
            public void ChargeControl_ChargeControlState_ReturnCharging_500mA()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 500;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Charging, _uut.chargeControlState);
            }

            [Test]
            public void ChargeControl_ChargeControlState_ReturnError()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 501;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Error, _uut.chargeControlState);
            }

            [Test]
            public void ChargeControl_Starts_Charging_OnDemand()
            {
                _uut.StartCharge();
                charger.Received().StartCharge();
            }

            [Test]
            public void ChargeControl_Stops_Charging_OnDemand()
            {
                _uut.StopCharge();
                charger.Received().StopCharge();
            }

            [Test]
            public void ChargeControl_Stops_Charging_When_Done()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 150;
                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Charging, _uut.chargeControlState);

                currentEventArgs.Current = 3;
                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Idle, _uut.chargeControlState);
            }
        }
    }
}
