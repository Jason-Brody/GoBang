using gobang.Models;
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

namespace gobang {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        List<Chess> items = new List<Chess>();

        private ChessBoard board = new ChessBoard();

        public MainWindow() {
            InitializeComponent();

            gd_result.DataContext = board;
            
            for(int i = 1; i <= 15; i++) {
                for(int j = 1; j <= 15; j++) {
                    items.Add(new Chess() {
                        X = j,
                        Y = i
                    });
                }
            }

           
            lv.ItemsSource = items;







            var converter = new gobang.Converters.LengthConverter();

            for (double i = 1; i < 16; i++) {
                Line l = new Line() {
                    Stroke = new SolidColorBrush(Colors.Black),
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

           

            for (double i = 1; i < 16; i++) {
                Line l = new Line() {
                    Stroke = new SolidColorBrush(Colors.Black),
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



        private void setCanvasBinding(DependencyObject depObj, DependencyProperty canvasProp, string path, Action<Binding> action = null) {
            Binding binding = new Binding();
            binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Canvas), 1);
            binding.Path = new PropertyPath(path);
            action?.Invoke(binding);
            BindingOperations.SetBinding(depObj, canvasProp, binding);
        }


        private void restart() {
            board = new ChessBoard();
            gd_result.DataContext = board;
            items = new List<Chess>();

            for (int i = 1; i <= 15; i++) {
                for (int j = 1; j <= 15; j++) {
                    items.Add(new Chess() {
                        X = j,
                        Y = i
                    });

                   
                }
            }

            lv.ItemsSource = items;
        }

        

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Chess chess = lv.SelectedItem as Chess;
            
            if (chess == null || chess.IsBlack != null)
                return;
            board.AddChess(new Point(chess.X, chess.Y), isBlack);

            isBlack = !isBlack;

            

            chess.IsBlack = isBlack;



        }



        private bool isBlack = false;

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            restart();
        }
    }
}
