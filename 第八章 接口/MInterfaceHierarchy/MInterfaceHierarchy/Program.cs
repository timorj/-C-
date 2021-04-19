using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInterfaceHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Square : IShape
    {
        void IDrawable.Draw()
        {
            Console.WriteLine("Drawing to the screen...");
        }
        void IPrintable.Draw() 
        {
            Console.WriteLine("Drawing to the printer...");
        }
        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }
    interface IDrawable
    {
        void Draw();
    }
    interface IPrintable 
    {
        void Draw();
        void Print();
    }
    interface IShape:IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }

}
