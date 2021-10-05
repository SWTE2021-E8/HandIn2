using NUnit.Framework;
using NSubstitute;

namespace Ladeskab___Mobile_charging_station.UnitTests
{
    [TestFixture()]
    public class Tests
    {
        IRfidReader uut;
        RfidDetectedEventArgs revievedEventArgs;

        [SetUp]
        public void Setup()
        {
            revievedEventArgs = null;

            uut = new RfidReader();
            uut.GetRfid("1111");

            //Setup of event listener
            uut.RfidDetectedEvent +=
                (o, args) =>
                {
                    revievedEventArgs = args;
                };
        }

        [Test]
        public void GetRfi_RfiRecieved_EventFired()
        {
            uut.GetRfid("100101");
            Assert.That(revievedEventArgs, Is.Not.Null);
        }
        [Test]
        public void GetRfi_RfiRecieved_RfidIs1100()
        {
            uut.GetRfid("1100");
            Assert.That(revievedEventArgs.Rfid, Is.EqualTo("1100"));
        }
        [Test]
        public void GetRfi_RfiRecieved_EventIsNull()
        {
            uut.GetRfid("1111");
            Assert.That(revievedEventArgs, Is.Null);
        }
    }
}