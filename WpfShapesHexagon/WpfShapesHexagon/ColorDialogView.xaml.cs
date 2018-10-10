// <copyright file="ColorDialogView.xaml.cs" company="8biTeam">
//     Copyright (c) 8biTeam. All rights reserved.
// </copyright>
namespace WpfShapesHexagon
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for ColorDialog.xaml
    /// </summary>
    public partial class ColorDialog : Window
    {
        /// <summary>
        /// Initialize a new instance of the ColorDialog class.
        /// </summary>
        public ColorDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Click "Ok" button to apply changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event mouse click</param>
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
