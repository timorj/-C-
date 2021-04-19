using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOps
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*****Fun with Overloaded operators******");
            Point pointOne = new Point(1, 1);
            Point pointTwo = new Point(2, 2);

            Console.WriteLine("pointOne = {0}", pointOne);
            Console.WriteLine("pointTwo = {0}", pointTwo);

            Console.WriteLine("pointOne + pointTwo:{0}", pointOne + pointTwo);

            Console.WriteLine("pointOne - pointTwo;{0}", pointOne - pointTwo);

            Console.WriteLine(--pointOne);
            Console.WriteLine(pointOne--);
            Console.WriteLine(pointOne--);
            Point p1 = new Point(1, 1);
            Point p2 = new Point(1, 1);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine("p1是否与p2相等：{0}",p1 == p2);

            Point p3 = new Point(2, 6);
            Point p4 = new Point(4, 4);

            Console.WriteLine("p3是否大于p4：{0}", p3 > p4);
        }
    }
    class Point:IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public override string ToString()
        {
            return string.Format("[{0},{1}]", X, Y);
        }
        public static Point operator +(Point p1, Point p2) 
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator -(Point p1, Point p2) 
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point operator ++(Point p1) 
        {
            return new Point(p1.X + 1, p1.Y + 1);
        }
        public static Point operator --(Point p1) 
        {
            return new Point(p1.X - 1, p1.Y - 1);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                return obj.ToString() == this.ToString();
            }

        }

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y) 
            {
                return 1;
            }
            else if(this.X < other.X && this.Y < other.Y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static bool operator >(Point p1, Point p2) 
        {
            return p1.CompareTo(p2) > 0;
        }
        public static bool operator <(Point p1, Point p2) 
        {
            return p1.CompareTo(p2) < 0;
        }

        public static bool operator <=(Point p1, Point p2) 
        {
            return p1.CompareTo(p2) <= 0;
        }
        public static bool operator >=(Point p1, Point p2) 
        {
            return p1.CompareTo(p2) >= 0;
        }

        public static bool operator ==(Point p1, Point p2) 
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Point p1, Point p2) 
        {
            return !p1.Equals(p2);
        }
    }
}
