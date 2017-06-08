using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace gobang.Models {
    public class AbstractNotifyChange : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;


        protected void SetProperty<T>(ref T item, T value, [CallerMemberName]string propertyName = null) {
            if (!EqualityComparer<T>.Default.Equals(item, value)) {
                item = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
