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

namespace OperatorTaxi
{
    /// <summary>
    /// Логика взаимодействия для AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : Window
    {
        public AddOrderView()
        {
            InitializeComponent();
          
            {
                InitializeComponent();
            }
            
        }
        private void AddOrder(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            if (this.startPoint.Text != "" && this.endPoint.Text != "" && this.count.Text != "")
            {
                try
                {
                    mainWindow.a.Orders.Add(new Order(this.startPoint.Text, this.endPoint.Text, Convert.ToInt32(this.count.Text), status.NotAppointed, "------"));
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Неправильно введені дані");
                }
            }
            else
            {
                MessageBox.Show("Ви не ввели всі дані");
            }
        }
    }
}
