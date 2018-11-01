﻿using System;
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
        public status APPOINTED { get; private set; }

        public ViewModels.MainWindowViewModel view;

        [TestMethod()]
        public void InitializationMainWindowTest()
        {
            String OrderPath = "Orders.txt";
            String TaxistPath = "Taxists.txt";

            String ExpectedOrderPath = "Orders.txt";
            String ExpectedTaxistPath = "Taxists.txt";

            view = new ViewModels.MainWindowViewModel(OrderPath, TaxistPath);
            Assert.AreEqual(ExpectedOrderPath, view.OrdersPath);
            Assert.AreEqual(ExpectedTaxistPath, view.TaxistsPath);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void WrongPathesTest()
        {
            String WrongOrdersPath = "WrongOrders.txt";
            String WrongTaxistsPath = "WrongTaxists.txt";

            String ExpectedOrdersPath = "Orders.txt";
            String ExpectedTaxistsPath = "Taxists.txt";

            view = new ViewModels.MainWindowViewModel(WrongOrdersPath, WrongTaxistsPath);

            Assert.AreEqual(ExpectedOrdersPath, view.OrdersPath);
            Assert.AreEqual(ExpectedTaxistsPath, view.TaxistsPath);
        }

        [TestMethod()]
        public void PathGetterAndSetterTest()
        {
            String OldOrdersPath = "Orders.txt";
            String OldTaxistsPath = "Taxists.txt";

            String UpdatedOrdersPath = "Orders1.txt";
            String UpdatedTaxistsPath = "Taxists1.txt";

            String ExpectedOrdersPath = "Orders1.txt";
            String ExpectedTaxistsPath = "Taxists1.txt";

            view = new ViewModels.MainWindowViewModel(OldOrdersPath,OldTaxistsPath);

            view.OrdersPath = UpdatedOrdersPath;
            view.TaxistsPath = UpdatedTaxistsPath;

            Assert.AreEqual(ExpectedOrdersPath, view.OrdersPath);
            Assert.AreEqual(ExpectedTaxistsPath, view.TaxistsPath);
        }

        [TestMethod()]
        public void SelectedOrderTest()
        {
            String OrdersPath = "Orders.txt";
            String TaxistsPath = "Taxists.txt";

            //Order data
            String Destination = "Shevchenka, 12";
            String CarNumber = "BC0173AC";
            String Where = "University, 1";
            Models.status Status = APPOINTED;
            int PassengersAmount = 1;

            Order order = new Order(Where, Destination, PassengersAmount, Status, CarNumber);

            //Taxist data
            bool isBusy = true;
            String Model = "Tesla";
            String Number = "BC0173AC";

            Taxist taxist = new Taxist(Model, Number, isBusy);

            view = new ViewModels.MainWindowViewModel(OrdersPath, TaxistsPath);

            view.SelectedOrder = order;
            view.SelectedTaxi = taxist;

            Assert.AreEqual(order, view.SelectedOrder);
            Assert.AreEqual(taxist, view.SelectedTaxi);
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
