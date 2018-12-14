using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorTaxi.Models;

namespace OperatorTaxiTests
{
    [TestClass]
    public class TaxistTests
    {
        [TestMethod()]
        public void TaxistDefaultConstructorTest()
        {
            Taxist obj = new Taxist();
            Assert.AreEqual(false, obj.IsBusy);
            Assert.AreEqual(null, obj.Model);
            Assert.AreEqual(null, obj.Number);
        }

        [TestMethod()]
        public void TaxistConstructorWithParamsTest()
        {
            //arrange

            bool isBusy = true;
            String Model = "Tesla";
            String Number = "BC0173AC";

            bool isBusyExpected = true;
            String ModelExpected = "Tesla";
            String NumberExpected = "BC0173AC";
            //act

            Taxist obj = new Taxist(Model,Number,isBusy);
            //assert

            Assert.AreEqual(isBusyExpected, obj.IsBusy);
            Assert.AreEqual(ModelExpected, obj.Model);
            Assert.AreEqual(NumberExpected, obj.Number);
        }

        [TestMethod()]
        public void GetModelTest()
        {
            //arrange

            String Model = "Tesla";
            String ModelExpected = "Tesla";
            //act

            Taxist obj = new Taxist();
            obj.Model = Model;
            //assert

            Assert.AreEqual(ModelExpected, obj.Model);
        }

        [TestMethod()]
        public void GetNumberTest()
        {
            //arrange

            String Number = "BC5703";
            String NumberExpected = "BC5703";
            //act

            Taxist obj = new Taxist();
            obj.Number = Number;
            //assert

            Assert.AreEqual(NumberExpected, obj.Number);
        }

        [TestMethod()]
        public void GetBusyStatusTest()
        {
            //arrange

            bool isBusy = true;
            bool isBusyExpected = true;
            //act

            Taxist obj = new Taxist();
            obj.IsBusy = isBusy;
            //assert

            Assert.AreEqual(isBusyExpected, obj.IsBusy);
        }
    }
}