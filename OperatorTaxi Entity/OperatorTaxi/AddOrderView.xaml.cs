namespace OperatorTaxi
{
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

    /// <summary>
    /// Логика взаимодействия для AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : Window
    {
        public AddOrderView()
        {
            InitializeComponent();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            if (this.where.Text != "" && this.destination.Text != "" && this.passengersAmount.Text != "")
            {
                try
                {
                    mainWindow.vm.Orders.Add(new Order(this.where.Text, this.destination.Text, Convert.ToInt32(this.passengersAmount.Text), status.NOTAPPOINTED, "------"));
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect input data!");
                }
            }
            else
            {
                MessageBox.Show("Enter all data!");
            }
        }
    }
}
