namespace AirConditionerTesterSystem.Tests
{
    using System;
    using BigMani.Controllers;
    using BigMani.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterStationaryAirConditionerTests
    {
        private AirConditionerController controller;

        [TestInitialize]
        public void TestInit()
        {
            this.controller = new AirConditionerController();
        }

        [TestMethod]
        public void CreatingAirConditioner_ShouldPrintSuccessMessage()
        {
            var stationaryCon = this.controller.RegisterStationaryAirConditioner("Ivan", "Ivanov", 'A', 1000);
            var expectedMessage = string.Format(Messages.Register, "Ivanov", "Ivan");

            Assert.AreEqual(stationaryCon, expectedMessage);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreatingAirConditionerWithIncorrectRating_ShouldThrowException()
        {
            var stationaryCon =
                this.controller.RegisterStationaryAirConditioner("Ivan", "Ivanov", 'Z', 1000);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreatingAirConditionerWithIncorrectPowerUsage_ShouldThrowException()
        {
            var stationaryCon =
                this.controller.RegisterStationaryAirConditioner("Ivan", "Ivanov", 'A', -1000);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreatingAirConditionerWithEmptyParams_ShouldThrowException()
        {
            var stationaryCon =
                this.controller.RegisterStationaryAirConditioner("", "", 'A', 1);
        }
    }
}