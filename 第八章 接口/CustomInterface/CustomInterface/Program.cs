using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with interfaces *****");

            /*  Hexagon hexagon = new Hexagon();
              IPointy itfPt2 = hexagon as IPointy;

              if(itfPt2 != null) 
              {
                  Console.WriteLine("Points:{0}", itfPt2.Points);
              }
              else
              {
                  Console.WriteLine("OOPS! Not Pointy...");
              }
              Console.WriteLine("Points:{0}", hexagon.Points);
              Console.ReadLine();*/

            Shape[] shapes = { new Hexagon(), new ThreeDCircle(), new Triangle(), new Circle("JoJo") };

            for (int i = 0; i < shapes.Length; i++)
            {
                shapes[i].Draw();

                if(shapes[i] is IPointy) 
                {
                    Console.WriteLine("-> Points: {0}", ((IPointy)shapes[i]).Points);
                }
                else
                {
                    Console.WriteLine("-> {0}\'s not pointy!", shapes[i].PetName);
                }
                Console.WriteLine();
                if(shapes[i] is IDraw3D) 
                {
                    DrawIn3D((IDraw3D)shapes[i]);
                }          
            }
            Console.Read();
        }
        static void DrawIn3D(IDraw3D itf3D) 
        {
            Console.WriteLine("->Drawing IDraw3D compatible type.");
            itf3D.Draw3D();
        }
    }
}
