using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorTaxi.Models;

namespace OperatorTaxiTests
{
    [TestClass]
    public class OrderTests
    {
        private status APPOINTED;

        public status NOTAPPOINTED { get; private set; }

        [TestMethod()]
        public void OrderDefaultConstructorTest()
        {
            Order obj = new Order();
            Assert.AreEqual(null, obj.CarNumber);
            Assert.AreEqual(null, obj.Destination);
            Assert.AreEqual(NOTAPPOINTED, obj.Status);
            Assert.AreEqual(null, obj.Where);
            Assert.AreEqual(0, obj.PassengersAmount);
        }

        [TestMethod()]
        public void OrderConstructorWithParamsTest()
        {
            //arrange

            String Destination = "Shevchenka, 12";
            String CarNumber = "BC0173AC";
            String Where = "University, 1";
            status Status = APPOINTED;
            int PassengersAmount = 1;

            String ExpectedDestination = "Shevchenka, 12";
            String ExpectedCarNumber = "BC0173AC";
            String ExpectedWhere = "University, 1";
            status ExpectedStatus = APPOINTED;
            int ExpectedPassengersAmount = 1;
            //act

            Order obj = new Order(Where, Destination, PassengersAmount, Status, CarNumber);
            //assert

            Assert.AreEqual(ExpectedDestination, obj.Destination);
            Assert.AreEqual(ExpectedCarNumber, obj.CarNumber);
            Assert.AreEqual(ExpectedWhere, obj.Where);
            Assert.AreEqual(ExpectedStatus, obj.Status);
            Assert.AreEqual(ExpectedPassengersAmount, obj.PassengersAmount);
        }

        [TestMethod()]
        public void GetDestinationTest()
        {
            //arrange

            String Destination = "Shevchenka, 1";
            String ExpectedDestination = "Shevchenka, 1";
            //act

            Order obj = new Order();
            obj.Destination = Destination;
            //assert

            Assert.AreEqual(ExpectedDestination, obj.Destination);
        }

        [TestMethod()]
        public void GetStatusTest()
        {
            //arrange

            status Status = APPOINTED;

            status ExpectedStatus = APPOINTED;
            //act

            Order obj = new Order();
            obj.Status = Status;
            //assert

            Assert.AreEqual(ExpectedStatus, obj.Status);
        }

        [TestMethod()]
        public void GetCarNumberTest()
        {
            //arrange

            String CarNumber = "BC5362AC";
            String ExpectedCarNumber = "BC5362AC";
            //act

            Order obj = new Order();
            obj.CarNumber = CarNumber;
            //assert

            Assert.AreEqual(ExpectedCarNumber, obj.CarNumber);
        }

        [TestMethod()]
        public void GetWhereTest()
        {
            //arrange

            String Where = "Shevchenka, 1";
            String ExpectedWhere = "Shevchenka, 1";
            //act

            Order obj = new Order();
            obj.Where = Where;
            //assert

            Assert.AreEqual(ExpectedWhere, obj.Where);
        }

        [TestMethod()]
        public void GetPassengersAmountTest()
        {
            //arrange

            int PassengersAmount = 1;
            
            int ExpectedPassengersAmount = 1;
            //act

            Order obj = new Order();
            obj.PassengersAmount = PassengersAmount;
            //assert

            Assert.AreEqual(ExpectedPassengersAmount, obj.PassengersAmount);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPassengerAmountOutOfBoundsTest()
        {
            int ExpectedPassengerAmount = 10;
            Order obj = new Order();
            obj.PassengersAmount = 10;

            Assert.AreEqual(ExpectedPassengerAmount, obj.PassengersAmount);
        }
    }
}
