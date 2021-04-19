using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Person p1 = new Person(firstName: "Pengfei", lastName: "Li", age: 22);
             Person p2 = new Person(firstName: "Pengfei", lastName: "Li", age: 22);
             Console.WriteLine(object.Equals(p1, p2));
             Console.WriteLine(object.ReferenceEquals(p1, p2));*/
            //  Static members of System.Object.
            Person p3 = new Person("Sally", "Jones", 4);
            Person p4 = new Person("Sally", "Jones", 4);
            Console.WriteLine("P3 and P4 have same state: {0}", object.Equals(p3, p4));
            Console.WriteLine("P3 and P4 are pointing to same object: {0}",
              object.ReferenceEquals(p3, p4));
            Console.ReadLine();
        }
    }
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public Person() { }
        public override string ToString()
        {
            string mystate;
            mystate = string.Format("[FirstName:{0}; LastName:{1}; Age: {2}]", FirstName, LastName, Age);
            return mystate;
        }
        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
