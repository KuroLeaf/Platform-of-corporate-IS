﻿namespace OperatorTaxi.ViewModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using OperatorTaxi.Models;

    public enum OE
    {
        ID,
        WHERE,
        DESTINATION,
        PAS_AMOUNT,
        STATUS,
        CAR_NUMBER
    }

    public enum TE
    {
        ID,
        MODEL,
        NUMBER,
        IS_BUSY
    }


    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Order selectedOrder;
        private Taxist selectedTaxi;
        private ObservableCollection<Order> orders;
        private ObservableCollection<Taxist> taxists;

        public string OrdersPath { get; set; }

        public string TaxistsPath { get; set; }

        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public Taxist SelectedTaxi
        {
            get
            {
                return selectedTaxi;
            }
            set
            {
                selectedTaxi = value;
                OnPropertyChanged("SelectedTaxi");
            }
        }

        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public ObservableCollection<Taxist> Taxists
        {
            get
            {
                return taxists;
            }
            set
            {
                taxists = value;
                OnPropertyChanged("Taxists");
            }
        }

        public MainWindowViewModel(string ordersPath, string taxistsPath)
        {
            this.OrdersPath = ordersPath;
            this.TaxistsPath = taxistsPath;
            Upload();
        }

        public void Save()
        {
            var lines1 = new string[Orders.Count];
            for (int i = 0; i < lines1.Length; ++i)
            {
                lines1[i] = Orders[i].Id + ", " + Orders[i].Where + ", " + Orders[i].Destination + ", " + Orders[i].PassengersAmount + ", " + Orders[i].Status + ", " + Orders[i].CarNumber;
            }
            File.WriteAllLines(OrdersPath, lines1);
            var lines2 = new string[Taxists.Count];
            for (int i = 0; i < lines2.Length; ++i)
            {
                lines2[i] = Taxists[i].Id + ", " + Taxists[i].Model + " " + Taxists[i].Number + " " + Taxists[i].IsBusy;
            }
            File.WriteAllLines(TaxistsPath, lines2);
        }

        public void DeleteOrder()
        {
            if (SelectedOrder != null && SelectedOrder.Status == status.APPOINTED)
            {
                foreach (var i in Taxists)
                {
                    if (SelectedOrder.CarNumber == i.Number)
                    {
                        i.IsBusy = false;
                    }
                }
            }
            Orders.Remove((SelectedOrder));
            SelectedOrder = Orders.Count != 0 ? Orders.First() : null;
        }

        public void DeleteTaxist()
        {
            if (SelectedTaxi != null && SelectedTaxi.IsBusy == true)
            {
                foreach (var i in Orders)
                {
                    if (SelectedTaxi.Number == i.CarNumber)
                    {
                        i.CarNumber = "------";
                        i.Status = status.NOTAPPOINTED;
                    }
                }
                Taxists.Remove(SelectedTaxi);
                SelectedTaxi = Taxists.Count != 0 ? Taxists.First() : null;
            }
        }

        public void Upload()
        {
            Orders = new ObservableCollection<Order>();
            if (!File.Exists(OrdersPath))
            {
                throw new  Exception("File does not exists!");

            }
            var lines = File.ReadAllLines(OrdersPath, Encoding.UTF8);
            string[] line;
            uint id;
            string where;
            string destination;
            int PassengersAmount;
            status stat;
            string carNumber;

            for (int i = 0; i < lines.Length; ++i)
            {
                line = lines[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Length > 1)
                {
                    carNumber = "------";
                    where = line[(int)OE.WHERE].Trim();
                    destination = line[(int)OE.DESTINATION].Trim();
                    int passengersAmountToParse;
                    if (!int.TryParse(line[(int)OE.PAS_AMOUNT].Trim(), out passengersAmountToParse))
                    {
                        throw new Exception("Incorrect input amount of passengers in file!");
                    }
                    PassengersAmount = passengersAmountToParse;

                    status statusToParse;
                    if (!status.TryParse(line[(int)OE.STATUS].Trim().ToUpper(), out statusToParse))
                    {
                        throw new Exception("Incorrect input status in file!");
                    }
                    stat = statusToParse;
                    if (line.Length == 5 && stat == status.APPOINTED)
                    {
                        carNumber = line[(int)OE.CAR_NUMBER].Trim();
                    }

                    Orders.Add(new Order(where, destination, PassengersAmount, stat, carNumber));
                }
            }

            Taxists = new ObservableCollection<Taxist>();
            if (!File.Exists(TaxistsPath))
            {
                throw new Exception("File does not exists.");
            }
            lines = File.ReadAllLines(TaxistsPath, Encoding.UTF8);
            string carModel;
            string number;
            bool isBusy;

            for (int i = 0; i < lines.Length; ++i)
            {
                line = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Length > 1)
                {
                    carModel = line[(int)TE.MODEL].Trim();
                    number = line[(int)TE.NUMBER].Trim();
                    bool isBusyToParse = false;
                    if (!bool.TryParse(line[(int)TE.IS_BUSY].Trim(), out isBusyToParse))
                    {
                        throw new Exception("Incorrect data about employment of taxist in file!");
                    }
                    isBusy = isBusyToParse;
       
                    Taxists.Add(new Taxist(carModel, number, isBusy));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}