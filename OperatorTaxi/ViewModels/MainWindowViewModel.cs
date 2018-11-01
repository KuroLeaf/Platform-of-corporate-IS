namespace ViewModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using Models;

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
                lines1[i] = Orders[i].Where + ", " + Orders[i].Destination + ", " + Orders[i].PassengersAmount + ", " + Orders[i].Status + ", " + Orders[i].CarNumber;
            }
            File.WriteAllLines(OrdersPath, lines1);
            var lines2 = new string[Taxists.Count];
            for (int i = 0; i < lines2.Length; ++i)
            {
                lines2[i] = Taxists[i].Model + " " + Taxists[i].Number + " " + Taxists[i].IsBusy;
            }
            File.WriteAllLines(TaxistsPath, lines2);
        }

        public void DeleteOrder()
        {
            if (SelectedOrder.Status == status.APPOINTED)
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
            if (SelectedTaxi.IsBusy == true)
            {
                foreach (var i in Orders)
                {
                    if (SelectedTaxi.Number == i.CarNumber)
                    {
                        i.CarNumber = "------";
                        i.Status = status.NOTAPPOINTED;
                    }
                }
            }
            Taxists.Remove(SelectedTaxi);
            SelectedTaxi = Taxists.Count != 0 ? Taxists.First() : null;
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
                    where = line[0].Trim();
                    destination = line[1].Trim();
                    int passengersAmountToParse;
                    if (!int.TryParse(line[2].Trim(), out passengersAmountToParse))
                    {
                        throw new Exception("Incorrect input amount of passengers in file!");
                    }
                    PassengersAmount = passengersAmountToParse;

                    status statusToParse;
                    if (!status.TryParse(line[3].Trim().ToUpper(), out statusToParse))
                    {
                        throw new Exception("Incorrect input status in file!");
                    }
                    stat = statusToParse;
                    if (line.Length == 5 && stat == status.APPOINTED)
                    {
                        carNumber = line[4].Trim();
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
                    carModel = line[0].Trim();
                    number = line[1].Trim();
                    bool isBusyToParse = false;
                    if (!bool.TryParse(line[2].Trim(), out isBusyToParse))
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