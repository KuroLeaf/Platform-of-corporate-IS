namespace OperatorTaxi
{
    using OperatorTaxi.ViewModels;
    using System.Windows;
    using System.Windows.Controls;

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
    }
}
