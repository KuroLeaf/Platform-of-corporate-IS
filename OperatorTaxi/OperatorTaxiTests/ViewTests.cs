using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.ObjectModel;

namespace OperatorTaxiTests
{
    [TestClass]
    public class ViewTests
    {
        public TestContext TestContext { get; set; }
        public Taxist Observable { get; private set; }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void InitializationMainWindowTest()
        {
            String OrderPath = "University, 1";
            String TaxistPath = "Shevchenko, 5";

            String ExpectedOrderPath = "University, 1";
            String ExpectedTaxistPath = "Shevchenko, 5";
            ViewModels.MainWindowViewModel view = new ViewModels.MainWindowViewModel(OrderPath, TaxistPath);
            Assert.AreEqual(ExpectedOrderPath, view.SelectedOrder.ToString());
        }

        //[TestMethod()]
        //public void DatabaseTest()
        //{
        //    String OrderPath = "University, 1";
        //    String TaxistPath = "Shevchenko, 5";

        //    String ExpectedOrderPath = "University, 1";
        //    String ExpectedTaxistPath = "Shevchenko, 5";
        //    ViewModels.MainWindowViewModel view = new ViewModels.MainWindowViewModel(OrderPath, TaxistPath);
        //    ObservableCollection <> view.Taxists;
        //    Assert.AreEqual(ExpectedOrderPath, view.SelectedOrder.ToString());

        //}

        //[TestMethod()]
        //public void OrderTest()
        //{
        //    String OrderPath = "University, 1";
        //    String TaxistPath = "Shevchenko, 5";

        //    String ExpectedOrderPath = "University, 1";
        //    String ExpectedTaxistPath = "Shevchenko, 5";
        //    ViewModels.MainWindowViewModel view = new ViewModels.MainWindowViewModel(OrderPath, TaxistPath);

        //    Assert.AreEqual(ExpectedOrderPath, view.SelectedOrder.Destination);
        //}

    }
}
