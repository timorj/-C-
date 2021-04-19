using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGrammerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Fun with Query Expressions****");
            ProductInfo[] itemInStock = new[]
            {
                new ProductInfo(){ Name = "Mac's Coffee",
                 Description = "Coffee with TEETH",
                 NumberInStock = 24},
                new ProductInfo(){Name = "Milk Maid Milk",
                 Description = "Milk cow's love",
                 NumberInStock = 100 },
                new ProductInfo()
                {
                    Name = "Pure Silk Tofu",
                     Description ="Bland as Possible",
                      NumberInStock = 120
                },
                new ProductInfo()
                {
                    Name = "Cruchy Pops",
                     Description = "Cheezy, peppery goodness",
                      NumberInStock = 100,
                },
                new ProductInfo()
                {
                    Name = "Classic Valpo Pizza",
                     Description ="Everyone loves pizza!",
                      NumberInStock = 73
                }
            };

            //SelectEverything(itemInStock);
            // SelectOverStock(itemInStock);
            //匿名类型linq投影查询
            //GetDescriptionAndNames(itemInStock);

            //GetCountFromQuery();
            //ReverseEverything(itemInStock);
            //AlphabetizeProductNames(itemInStock);
            // DisplayDiff();
            //DisplayIntersection();
            //DisplayUnion();
            // DisplayConcat();
            // DisplayConcatNoDups();
            AggregateOps();
            Console.ReadLine();
        }
        static void AggregateOps() 
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            Console.WriteLine("Max temp:{0}", winterTemps.Max());

            Console.WriteLine("Min temp:{0}", winterTemps.Min());

            Console.WriteLine("Avarage temp:{0}", winterTemps.Average());

            Console.WriteLine("Sun of all temps:{0}", winterTemps.Sum());
        }
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carConcat = myCars.OfType<string>().Concat(yourCars.OfType<string>());

            foreach (var item in carConcat.Distinct())
            {
                Console.WriteLine(item);
            }
        }
        static void SelectEverything(ProductInfo[] products) 
        {
            Console.WriteLine("All Product details");
            var allProducts = from i in products select i;

            foreach (var item in allProducts)
            {
                Console.WriteLine(item);
            }
        }
        static void SelectOverStock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items!");

            var overstock = from i in products where i.NumberInStock > 25 select i;
            foreach (var item in overstock)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void GetDescriptionAndNames(ProductInfo[] products)
        {
            Console.WriteLine("Names and descriptions");

            var nameDesc = from i in products select new { i.Name, i.Description };

            foreach (var item in nameDesc)
            {
                Console.WriteLine(item);
            }
        }
        static void GetCountFromQuery()
        {
            string[] currentVideoGames = { "Morrowind", "UnCharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            int numb = (from i in currentVideoGames where i.Length > 6 select i).Count();

            Console.WriteLine("{0} items honor the Linq query.", numb);
        }
        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Product in revers:");
            var allProducts = products.OfType<ProductInfo>();

            foreach (var item in allProducts.Reverse())
            {
                Console.WriteLine(item);
            }
        }
        static void AlphabetizeProductNames(ProductInfo[] products) 
        {
            var subset = from i in products orderby i.Name descending select i;
            Console.WriteLine("Ordered by Name:");
            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }
        }
        static void DisplayDiff()
        {
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you don't have, but i do:");

            foreach (var item in carDiff)
            {
                Console.WriteLine(item);
            }

        }
        static void DisplayIntersection()
        {
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carIntersect = myCars.OfType<string>().Intersect(yourCars.OfType<string>());

            Console.WriteLine("Here is what we both have:");
            foreach (var item in carIntersect)
            {
                Console.WriteLine(item);
            }
        }
        static void DisplayUnion() 
        {
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carUnion = myCars.OfType<string>().Union(yourCars.OfType<string>());

            Console.WriteLine("here is evething..");
            foreach (var item in carUnion)
            {
                Console.WriteLine(item);
            }
        }
        static void DisplayConcat()
        {
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carConcat = myCars.OfType<string>().Concat(yourCars.OfType<string>());

            foreach (var item in carConcat)
            {
                Console.WriteLine(item);
            }
        }
    }
    class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }

        public override string ToString()
        {
            return string.Format("Name = {0}, Description = {1}, Number in Stock = {2}", Name, Description, NumberInStock);
        }
    }
}
