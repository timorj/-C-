using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Annoymous Types*******");

            BuildAnonType("Bright Pink", "Pink", 20);

            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            ReflectOverAnonymousType(myCar);
        }
        static void BuildAnonType(string make, string color, int currSp) 
        {
            var car = new { Make = make, Color = color, Currsp = currSp };

            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Currsp);

            Console.WriteLine("ToString() == {0}", car.ToString());
        }
        static void ReflectOverAnonymousType(object obj) 
        {
            Console.WriteLine("obj is an instance of:{0}", obj.GetType().Name);


            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);

            Console.WriteLine("obj.ToString() == {0}", obj.ToString());

            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());

            Console.WriteLine();

        }
    }
}
