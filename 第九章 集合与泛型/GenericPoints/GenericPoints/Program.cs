using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Generic Structures*****");

            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine("p.ToString() = {0}", p.ToString());

            p.ResetPoint();
            Console.WriteLine("p.ToString() = {0}", p.ToString());
            Console.WriteLine();

        }
    }
    public struct Point<T>
    {
        private T xPos;
        private T yPos;

        public Point(T xVal, T yVal)
        {
            xPos = xVal;
            yPos = yVal;
        }
        public T X { get => xPos; set => xPos = value; }
        public T Y { get => yPos; set => yPos = value; }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", xPos, yPos);
        }

        public void ResetPoint() 
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
}
