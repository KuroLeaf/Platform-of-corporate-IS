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
using System.Windows.Shapes;
using Models;

namespace OperatorTaxi
{
    /// <summary>
    /// Логика взаимодействия для TaxiView.xaml
    /// </summary>
    public partial class TaxiView : Window
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
        public AddTaxistView _addTaxist;

        public TaxiView()
        {
            InitializeComponent();
        }

        private void SetTaxi(object sender, RoutedEventArgs e)
        {
            if (mainWindow.vm.SelectedOrder != null && mainWindow.vm.SelectedTaxi != null)
            {
                if (mainWindow.vm.SelectedTaxi.IsBusy == false)
                {
                    mainWindow.vm.SelectedTaxi.IsBusy = true;
                    mainWindow.vm.SelectedOrder.Status = status.APPOINTED;
                    mainWindow.vm.SelectedOrder.CarNumber = mainWindow.vm.SelectedTaxi.Number;
                    mainWindow.orderListView.Items.Refresh();
                    Taxists.Items.Refresh();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The taxist is busy!");
                }
            }
            else
            {
                MessageBox.Show("In order to set a taxist you have to choose order and free taxist!");
            }
        }

        private void AddTaxist(object sender, RoutedEventArgs e)
        {
            _addTaxist = new AddTaxistView();
            _addTaxist.Show();
        }

        private void DeleteTaxist(object sender, RoutedEventArgs e)
        {
            mainWindow.vm.DeleteTaxist();
            mainWindow.orderListView.Items.Refresh();
        }
    }
}
