using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with Conversions******");

            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Console.WriteLine();

            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();


            Rectangle rt = new Rectangle(5, 8);
            DrawSquare((Square)rt);
            //Console.ReadLine();

            int length = 2;
            Square si = (Square)length;

            DrawSquare(si);

            Square its = new Square(3);
            Console.WriteLine((int)its);

            Console.WriteLine("********隐式类型转换*********");
            Square iss = new Square(2);
            Rectangle rectangle = iss;
            rectangle.Draw();
            Console.ReadLine();
        }
        static void DrawSquare(Square sq) 
        {
            Console.WriteLine(sq.ToString());
            sq.Draw();
        }
    }
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h):this()
        {
            Width = w;
            Height = h;
        }

        public void Draw() 
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return string.Format("[Width = {0};Height = {1}]", Width, Height);

        }

        public static implicit operator Rectangle(Square s) 
        {
            Rectangle r = new Rectangle();
            r.Height = s.Length;

            r.Width = s.Length * 2;
            return r;
        }

        

    }
    public struct Square 
    {
        public int Length { get; set; }

        public Square(int l):this()
        {
            Length = l;
        }

        public void Draw() 
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return string.Format("[Length = {0}]", Length);
        }

        public static explicit operator Square(Rectangle r) 
        {
            Square s = new Square();
            s.Length = r.Height;
            return s;
        }
        public static explicit operator Square(int sideLength) 
        {
            Square s = new Square(sideLength);
            return s;
        }
        public static explicit operator int(Square s) 
        {
            return s.Length;
        }
    }

}
