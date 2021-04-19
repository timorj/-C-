using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Octagon octagon = new Octagon();

            IDrawForm itfForm = (IDrawForm)octagon;
            itfForm.Draw();

            IDrawMemory itfMemory = (IDrawMemory)octagon;
            itfMemory.Draw();

            IDrawToPrinter itfPrinter = (IDrawToPrinter)octagon;
            itfPrinter.Draw();

            Console.ReadLine();
        }
    }
    public interface IDrawForm
    {
        void Draw();
    }
    public interface IDrawMemory
    {
        void Draw();
    }
    public interface IDrawToPrinter
    {
        void Draw();
    }

    class Octagon:IDrawForm, IDrawMemory, IDrawToPrinter
    {
        void IDrawForm.Draw() => Console.WriteLine("Drawing to Form...");

        void IDrawMemory.Draw()
        {
            Console.WriteLine("Drawing to memory...");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to Printer...");
        }
    }
}
