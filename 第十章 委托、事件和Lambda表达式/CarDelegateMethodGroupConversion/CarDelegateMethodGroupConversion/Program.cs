using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegateMethodGroupConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Method Group Conversion******");
            Car c1 = new Car("sliy", 100, 10);

            c1.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("*********speed up!*************");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            c1.UnRegisterWithCarEngine(CallMeHere);

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        private static void CallMeHere(string msgForCaller)
        {
            Console.WriteLine("=> Message from Car:{0}", msgForCaller);
        }
    }
    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        private CarEngineHandler listOfHandler;

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandler += methodToCall;
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandler -= methodToCall;
        }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool isCarDead;

        public Car()
        {

        }
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }

        public void Accelerate(int delta)
        {
            if (isCarDead)
            {
                if (listOfHandler != null)
                {
                    listOfHandler("Sorry, this car is dead...");
                }
            }
            else
            {
                CurrentSpeed += delta;

                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandler != null)
                {
                    listOfHandler("Careful buddy! Gonna blow!");
                }

                if (CurrentSpeed > MaxSpeed)
                {
                    isCarDead = true;

                }
                else
                {
                    Console.WriteLine("CurrentSpeed is: {0}.", CurrentSpeed);
                }
            }
        }
    }
}
