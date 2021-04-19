using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage carLot = new Garage();

            foreach (Car car in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH.", car.PetName, car.CurrentSpeed);

            }
            Console.Read();
        }
    }

}
