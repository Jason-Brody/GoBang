using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Diagnostics;

namespace gobang.Models {
    public class ChessBoard :AbstractNotifyChange{

        private Dictionary<Point, bool> chessDic = new Dictionary<Point, bool>();

        private bool win;

        public bool IsWin {
            get { return win; }
            set { SetProperty(ref win, value); }
        }

        private bool isBlack = false;

        public void AddChess(Point p,bool type) {
            
            IsWin = isWin(p, isBlack);
            chessDic.Add(p, isBlack);
            isBlack = !isBlack;
        }

        

        private bool isWin(Point chess,bool type) {

            int right = findCount((p) => new Point(p.X+1,p.Y),chess, type, 0);
            int left = findCount((p) => new Point(p.X-1, p.Y), chess, type, 0);
            int top = findCount((p) => new Point(p.X, p.Y - 1), chess, type, 0);
            int bottem = findCount((p) => new Point(p.X, p.Y + 1), chess, type, 0);
            int topLeft = findCount((p) => new Point(p.X - 1, p.Y - 1), chess, type, 0);
            int bottemLeft = findCount((p) => new Point(p.X - 1, p.Y + 1), chess, type, 0);
            int topRight = findCount((p) => new Point(p.X + 1, p.Y - 1), chess, type, 0);
            int bottemRight = findCount((p) => new Point(p.X + 1, p.Y + 1), chess, type, 0);

            List<int> result = new List<int>();
            result.Add(left + right);
            result.Add(top + bottem);
            result.Add(topLeft + bottemRight);
            result.Add(topRight + bottemLeft);

            Debug.WriteLine("X:" + chess.X);
            Debug.WriteLine("Y:" + chess.Y);

            if (result.Any(n => n >= 4)) {
                Debug.WriteLine("right      :" + right);
                Debug.WriteLine("left       :" + left);
                Debug.WriteLine("top        :" + top);
                Debug.WriteLine("bottem     :" + bottem);
                Debug.WriteLine("topLeft    :" + topLeft);
                Debug.WriteLine("bottemLeft :" + bottemLeft);
                Debug.WriteLine("topRight   :" + topRight);
                Debug.WriteLine("bottemRight:" + bottemRight);
                return true;
                
                


            }
            return false;
        }

        private int findCount(Func<Point,Point> findMethod,Point point,bool type,int currentCount) {
            Point p = findMethod(point);
            if (chessDic.ContainsKey(p)) {
                if(chessDic[p] == type) {
                    return findCount(findMethod,p, type, ++currentCount);
                }
            }
            return currentCount;
        }
    }
}
