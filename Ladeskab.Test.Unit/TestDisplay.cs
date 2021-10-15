using System;
using System.IO;
using NUnit.Framework;
using Ladeskab;

namespace Ladeskab.Test.Unit
{
    [TestFixture]
    public class TestDisplay
    {
        public Display uut;

        [SetUp]
        public void Setup()
        {
            uut = new Display();
        }

        [Test]
        public void Test_DisplayMsg_Outputs_To_Console()
        {
            // Arrange
            var expected = "Display: Test\n";
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            uut.DisplayMsg("Test");

            // Assert
            var actual = output.ToString();
            Assert.AreEqual(expected, actual);
        }

    }
}
