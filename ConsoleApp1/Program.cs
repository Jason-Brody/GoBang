using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            DoProcessing();
            Console.ReadLine();
        }

        public static void DoProcessing() {
            TraceMessage("Something happened.");

            Point p = new Point(3, 4);
            Dictionary<Point, int> chess = new Dictionary<Point, int>();
            chess.Add(p, 0);

            Point p1 = new Point(3, 4);
            if (chess.ContainsKey(p1)) {
                Console.WriteLine("Contains");
            }

            p.X = 5;
            if (chess.ContainsKey(p1)) {
                Console.WriteLine("Contains");
            }

            
            

        }

        public static void TraceMessage(string message,
                [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
                [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0) {
            Console.WriteLine("message: " + message);
             Console.WriteLine("member name: " + memberName);
             Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }
    }

    
}
