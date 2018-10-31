using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels;

namespace OperatorTaxi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TaxiView Taxi;
        public AddOrderView addOrder;
        public MainWindowViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel("Orders.txt", "Taxists.txt");
            this.DataContext = vm;
        }

        private void Taxists(object sender, RoutedEventArgs e)
        {
            Taxi = new TaxiView();
            Taxi.DataContext = vm;
            Taxi.Show();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            addOrder = new AddOrderView();
            addOrder.Show();
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedOrder != null)
            {
                vm.DeleteOrder();
            }
            else
            {
                MessageBox.Show("TO DELETE SOMETHING YOU MUST PICK ONE FIRST!!!");
            }
           

        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            vm.Save();
        }

        private void UploadData(object sender, RoutedEventArgs e)
        {
            vm.Upload();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void orderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
