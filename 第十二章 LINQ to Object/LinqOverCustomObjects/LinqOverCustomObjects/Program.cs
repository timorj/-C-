using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCustomObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Linq over gengeric collections******\n");

            List<Car> myCars = new List<Car>()
            {
                new Car { PetName = "Henry", Color = "Sliver", Speed = 100,  Make = "BMW"},
                new Car { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { PetName = "Mary", Color = "Black", Speed = 55, Make = "VW" },
                new Car { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };
            GetFastCars(myCars);
            Console.WriteLine();

            LinqOverArrayList();
            Console.ReadLine();
         }
        static void GetFastCars(List<Car> myCars) 
        {
            var fastCars = from i in myCars where i.Speed > 55 && i.Make == "BMW" select i;
            foreach (var item in fastCars)
            {
                Console.WriteLine(item);
            }
        }
        static void LinqOverArrayList()
        {
            ArrayList myCars = new ArrayList()
            {
                new Car { PetName = "Henry", Color = "Sliver", Speed = 100,  Make = "BMW"},
                new Car { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { PetName = "Mary", Color = "Black", Speed = 55, Make = "VW" },
                new Car { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };

            var myCarsEum = myCars.OfType<Car>();

            var fastCars = from i in myCarsEum where i.Speed > 50 select i;

            foreach (var item in fastCars)
            {
                Console.WriteLine(item);
            }

        }
    }
    class Car
    {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }

        public override string ToString()
        {
            return string.Format("PetName:{0}, Color:{1}, Speed:{2}, Make:{3}", PetName, Color, Speed, Make);
        }
    }
}
