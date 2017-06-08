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

namespace WpfApp1 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            LengthConverter converter = new LengthConverter();

            for(double i = 1; i < 15; i++) {
                Line l = new Line() {
                    Stroke = new SolidColorBrush(Colors.Red),
                    Stretch = Stretch.Fill,
                    X1 = 1,
                };


                setCanvasBinding(l, WidthProperty, nameof(ActualWidth));
                setCanvasBinding(l, Canvas.TopProperty, nameof(ActualHeight), b => {
                    b.Converter = converter;
                    b.ConverterParameter = i;
                });
                cv.Children.Add(l);
            }

            for (double i = 1; i < 15; i++) {
                Line l = new Line() {
                    Stroke = new SolidColorBrush(Colors.Red),
                    Stretch = Stretch.Fill,
                    Y1 = 1,
                };


                setCanvasBinding(l, HeightProperty, nameof(ActualHeight));
                setCanvasBinding(l, Canvas.LeftProperty, nameof(ActualWidth), b => {
                    b.Converter = converter;
                    b.ConverterParameter = i;
                });
                cv.Children.Add(l);
            }


        }

        private void setCanvasBinding(DependencyObject depObj,DependencyProperty canvasProp,string path,Action<Binding> action = null) {
            Binding binding = new Binding();
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Canvas), 1);
            binding.Path = new PropertyPath(path);
            action?.Invoke(binding);
            BindingOperations.SetBinding(depObj, canvasProp, binding);
        }


    }
}
