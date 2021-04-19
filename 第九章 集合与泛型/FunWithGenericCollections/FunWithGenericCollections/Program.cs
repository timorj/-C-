using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // GenericQueue();
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge()){
                new Person("homer", "simplon", 47),
                new Person("marge", "Simplon", 22),
                new Person("lisa", "Simplon", 25),
                new Person("bart", "Simplon", 66)
            };
            foreach (var sp in setOfPeople)
            {
                Console.WriteLine(sp);
            }
            Console.WriteLine();

            setOfPeople.Add(new Person("1", "2", 455));
            setOfPeople.Add(new Person("penge", "li", 0));
            foreach (var sp in setOfPeople)
            {
                Console.WriteLine(sp);
            }
        }
        static void GenericQueue()
        {
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person("homer", "simplon", 47));
            peopleQ.Enqueue(new Person("Marge", "Simplon", 45));
            peopleQ.Enqueue(new Person("Lisa", "Simplon", 8));

            Console.WriteLine("{0} is first in line!", peopleQ.Peek().FirstName);

            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static  void GetCoffee(Person p) 
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }
    }
   
    class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {

        }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return string.Format("Name:{0}{1}, Age:{2}", FirstName, LastName, Age);
        }
    }
}
