namespace OperatorTaxi
{
    using System;
    using System.Windows;
    using Models;

    /// <summary>
    /// Логика взаимодействия для AddTaxistView.xaml
    /// </summary>
    public partial class AddTaxistView : Window
    {
        public AddTaxistView()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            if (this.Model.Text != "" && this.Number.Text != "")
            {
                try
                {
                    mainWindow.vm.Taxists.Add(new Taxist(this.Model.Text, this.Number.Text, false));
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
