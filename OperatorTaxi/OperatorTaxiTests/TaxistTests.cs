using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OperatorTaxiTests
{
    [TestClass]
    public class TaxistTests
    {
        [TestMethod()]
        public void TaxistDefaultConstructorTest()
        {
            Models.Taxist obj = new Models.Taxist();
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

            Models.Taxist obj = new Models.Taxist(Model,Number,isBusy);
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

            Models.Taxist obj = new Models.Taxist();
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

            Models.Taxist obj = new Models.Taxist();
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

            Models.Taxist obj = new Models.Taxist();
            obj.IsBusy = isBusy;
            //assert

            Assert.AreEqual(isBusyExpected, obj.IsBusy);
        }
    }
}