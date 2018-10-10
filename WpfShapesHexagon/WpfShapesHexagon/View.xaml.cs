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
            DataContext = vm;
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
        {
            if (vm.Mode == MovingDrawingEnum.Moving.ToString() && !isMoving)
            {
                point = new Point(vm.XPos, vm.YPos);
                pointO = new Point(Canvas.GetLeft(sender as UIElement), Canvas.GetTop(sender as UIElement));
                isMoving = true;
                var element = (UIElement)sender;
                element.CaptureMouse();
                Panel.SetZIndex(element, 1);
            }
        }

        private void MouseMoveShape(object sender, MouseEventArgs e)
        {
            if (vm.Mode == MovingDrawingEnum.Moving.ToString() && isMoving)
            {
                var element = (UIElement)sender;
                Canvas.SetLeft(element, pointO.X + vm.XPos - point.X);
                Canvas.SetTop(element, pointO.Y + vm.YPos - point.Y);
            }
        }

        private void MouseUpShape(object sender, MouseButtonEventArgs e)
        {
            if (isMoving && vm.Mode == MovingDrawingEnum.Moving.ToString())
            {
                var element = (UIElement)sender;

                element.ReleaseMouseCapture();
                Canvas.SetZIndex(element, 0);
                isMoving = false;
            }
        }
    }

    public enum MovingDrawingEnum
    {
        Moving,
        Drawing
    }
}