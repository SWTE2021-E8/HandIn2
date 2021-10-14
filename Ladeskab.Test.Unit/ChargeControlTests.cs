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
    class ChargeControlTests
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
            public void ChargeControl_ChargeControlState_ReturnCharging()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 150;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Charging, _uut.chargeControlState);
            }
            [Test]
            public void ChargeControl_ChargeControlState_ReturnIdle()
            {   
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 500;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Idle, _uut.chargeControlState);
            }
            [Test]
            public void ChargeControl_ChargeControlState_ReturnError()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 700;

                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                Assert.AreEqual(ChargeControl.ChargeControlState.Error, _uut.chargeControlState);
            }

            public void ChargeControl_StopCharge_WasNotChargingNowIsCharging()
            {
                CurrentEventArgs currentEventArgs = new CurrentEventArgs();
                currentEventArgs.Current = 150;
                charger.CurrentValueEvent += Raise.EventWith(currentEventArgs);

                _uut.StopCharge();
                Assert.IsTrue(charger.CurrentValue == 0);

                _uut.StartCharge();
                Assert.IsTrue(charger.CurrentValue != 0);
            }
        }
    }
}
