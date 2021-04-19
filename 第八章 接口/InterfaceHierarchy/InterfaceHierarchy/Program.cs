using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.Draw();
            bitmap.DrawInBoundingBox(1,2,3,4);
            bitmap.DrawUpsideDown();

            IAdvanceDraw iAdvrDraw = bitmap as IAdvanceDraw;
            if(iAdvrDraw != null) 
            {
                iAdvrDraw.DrawUpsideDown();
            }
            Console.Read();
        }
    }
    class BitmapImage : IAdvanceDraw
    {
        public void Draw()
        {
            Console.WriteLine("Draw...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing a box");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down!");
        }
    }

    public interface IDrawable
    {
        void Draw();
    }
    public interface IAdvanceDraw:IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }
}
