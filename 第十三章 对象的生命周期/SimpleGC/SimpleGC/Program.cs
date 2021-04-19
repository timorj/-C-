using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Fun with System.GC*****");

            Console.WriteLine("Estimated bytes on heap:{0}", GC.GetTotalMemory(false));

            Console.WriteLine("This OS has {0} object generations.\n", GC.MaxGeneration +1);

            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());

            object[] tonOfObjects = new object[50000];
            for (int i = 0; i < tonOfObjects.Length; i++)
            {
                tonOfObjects[i] = new object();
            }

            GC.Collect(0);
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

            if (tonOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonOfObjects[9000] is: {0}", GC.GetGeneration(tonOfObjects[9000]));
             
            }
            else
            {
                Console.WriteLine("tonOfObjects[9000] is no longer alive.");
            }

            Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("\nGen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("\nGen 2 has been swept {0} times", GC.CollectionCount(2));

            Console.ReadLine();
        }
    }
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public string Name { get; set; }

        public Car()
        {
        }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} is going {1} MPH", Name, CurrentSpeed);
        }
    }
}
