// <copyright file="View.xaml.cs" company="8biTeam">
//     Copyright (c) 8biTeam. All rights reserved.
// </copyright>
namespace WpfShapesHexagon
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point point;
        Point pointO;
        ViewModel vm = new ViewModel();
        bool isMoving = false;
        bool isDrawing = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {}

        private void Open_Click(object sender, RoutedEventArgs e)
        {}

        private void New_Click(object sender, RoutedEventArgs e)
        {}

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MovingMode_Click(object sender, RoutedEventArgs e)
        {
            if (isDrawing)
            {
                vm.Polygones.RemoveAt(vm.Count - 1);
                isDrawing = false;
            }
            vm.Mode = MovingDrawingEnum.Moving.ToString();
        }

        private void DrawingMode_Click(object sender, RoutedEventArgs e)
        {
            vm.Mode = MovingDrawingEnum.Drawing.ToString();
        }

        private void CanvasArea_MouseMove(object sender, MouseEventArgs e)
        { }

        private void CanvasArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { }

        private void MouseDownShape(object sender, MouseButtonEventArgs e)
        {}

        private void MouseMoveShape(object sender, MouseEventArgs e)
        {}

        private void MouseUpShape(object sender, MouseButtonEventArgs e)
        {}
    }

    public enum MovingDrawingEnum
    {
        Moving,
        Drawing
    }
}