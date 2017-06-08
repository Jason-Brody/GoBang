using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang.Models {
    public class Chess:AbstractNotifyChange {

        private bool? isBlack;

        public string Content { get; set; }

        public bool? IsBlack {
            get { return isBlack; }
            set { SetProperty(ref isBlack, value); }
        }

        public int X { get; set; }

        public int Y { get; set; }

        
    }
}
