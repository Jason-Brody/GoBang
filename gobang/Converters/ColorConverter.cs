using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;
using gobang.Models;
using System.Windows.Media;

namespace gobang.Converters {
    public class ColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null) {
                return new SolidColorBrush(Colors.Transparent);
            }
            bool v = (bool)value;
            if(v == true) {
                return new SolidColorBrush(Colors.Black);
            } else {
                return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
