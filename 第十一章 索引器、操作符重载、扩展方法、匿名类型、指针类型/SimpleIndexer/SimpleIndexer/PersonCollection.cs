using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    public class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();
        public Person this[string name] 
        {
            get => listPeople[name];
            set => listPeople[name] = value;
        }

        public void ClearPeople() 
        {
            listPeople.Clear();
        }

        public int Count {
            get => listPeople.Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in listPeople)
            {
                yield return item;
            }
        }


        /* //private ArrayList arPeople = new ArrayList();


         //indexer
         public Person this[int pos] 
         {
             get => (Person)arPeople[pos];
             set => arPeople.Insert(pos, value);
         }
         // Cast for caller.
         public Person GetPerson(int pos)
         { return (Person)arPeople[pos]; }

         // Only insert Person objects.
         public void AddPerson(Person p)
         { arPeople.Add(p); }

         public void ClearPeople()
         { arPeople.Clear(); }

         public int Count
         { get { return arPeople.Count; } }

         // Foreach enumeration support.
         IEnumerator IEnumerable.GetEnumerator()
         { return arPeople.GetEnumerator(); }*/
    }
}
