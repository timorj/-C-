using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBoxUnboxOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonCollection persons = new PersonCollection();
            persons.AddPerson(new Person("li", "pengfei", 22));
            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
    class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();
        public Person GetPerson(int pos) 
        {
            return (Person)arPeople[pos];
        }

        public void AddPerson(Person p) 
        {
            arPeople.Add(p);
        }
        public void ClearPerson() 
        {
            arPeople.Clear();
        }
        public int Count { get => arPeople.Count;  }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in arPeople)
            {
                yield return item;
            }
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
