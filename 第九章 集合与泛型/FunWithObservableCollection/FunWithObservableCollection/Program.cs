using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FunWithObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ObservableCollection<Person> people = new ObservableCollection<Person>() {
                new Person("Peter", "Murphy", 52),
                new Person("Kevin", "Key", 48)
            };
            people.CollectionChanged += people_CollectionChanged;
            people.Add(new Person("li", "pengfei", 22));*/
            Console.WriteLine("{0}:f3", GetPower(2, 3).ToString());
            
        }
        static double GetPower(double x, double y) 
        {
            double s = Math.Pow(x, y);
            return s;
        }
        static void people_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) 
        {
            Console.WriteLine("Action for this event:{0}", e.Action);
            if(e.Action == NotifyCollectionChangedAction.Remove) 
            {
                Console.WriteLine("here are olditems");
                foreach (Person person in e.OldItems)
                {
                    Console.WriteLine(person.ToString());
                }

            }
            if (e.Action == NotifyCollectionChangedAction.Add) 
            {
                Console.WriteLine("here are new items");
                foreach (Person person in e.NewItems)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            Console.WriteLine();
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
