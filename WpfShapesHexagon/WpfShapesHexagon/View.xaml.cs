// <copyright file="View.xaml.cs" company="8biTeam">
//     Copyright (c) 8biTeam. All rights reserved.
// </copyright>
namespace WpfShapesHexagon
{
    using System.Collections.ObjectModel;
    using Microsoft.Win32;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows;
    using System.Windows.Input;
   

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

        private void Save_as_Click(object sender, RoutedEventArgs e)
        {
            string _path = "File.xml";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".xml";
            if (dialog.ShowDialog() == true)
            {
                _path = dialog.FileName;
            }
            vm.Serialize(_path);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (sender == null)
            {
                throw new System.ArgumentNullException(nameof(sender));
            }

            string _path = "File.xml";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xml";
            if (dialog.ShowDialog() == true)
            {
                _path = dialog.FileName;
            }
            vm.Deserialize(_path);
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (e == null)
            {
                throw new System.ArgumentNullException(nameof(e));
            }

            if (isDrawing)
            {
                vm.Polygones.RemoveAt(vm.Count - 1);
                isDrawing = false;
            }
            vm.Polygones = new ObservableCollection<Polygon>();
        }

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
        {
            vm.YPos = (int)Mouse.GetPosition(sender as UIElement).Y;
            vm.XPos = (int)Mouse.GetPosition(sender as UIElement).X;

            if (vm.Mode == MovingDrawingEnum.Drawing.ToString() && isDrawing)
            {
                vm.Change_Last(new Point(vm.XPos, vm.YPos));
            }
        }

        private void CanvasArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (vm.Mode == MovingDrawingEnum.Drawing.ToString())
            {
                if (!isDrawing)
                {
                    isDrawing = true;
                    vm.Add(new Polygon() { Points = new PointCollection() { new Point(vm.XPos, vm.YPos), new Point(vm.XPos, vm.YPos) }, Fill = Brushes.LightGoldenrodYellow, Stroke = Brushes.Black });
                }
                else
                {
                    vm.Add_Last(new Point(vm.XPos, vm.YPos));
                    if (vm.Count_Last >= 7)
                    {
                        ColorDialog colorDialog = new ColorDialog();
                        colorDialog.Owner = this;
                        colorDialog.fillColorPicker.SelectedColor = (vm.Polygones.Last().Fill as SolidColorBrush).Color;
                        colorDialog.strokeColorPicker.SelectedColor = (vm.Polygones.Last().Stroke as SolidColorBrush).Color;
                        colorDialog.ShowDialog();
                        if (colorDialog.DialogResult == true)
                        {
                            vm.Polygones.Last().Fill = new SolidColorBrush((Color)colorDialog.fillColorPicker.SelectedColor);
                            vm.Polygones.Last().Stroke = new SolidColorBrush((Color)colorDialog.strokeColorPicker.SelectedColor);
                        }
                        isDrawing = false;
                    }
                }
            }
        }

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