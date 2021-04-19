using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enables *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            Car.CarEngineHandler engineHandler = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));

            c1.UnRegisterWithCarEngine(engineHandler);
            Console.WriteLine("******Speeding up!********");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        private static void OnCarEngineEvent2(string msgForCaller)
        {
            Console.WriteLine("=>{0}", msgForCaller.ToUpper());
        }

        private static void OnCarEngineEvent(string msgForCaller)
        {
            Console.WriteLine("\n***** Message from Car object *****");
            Console.WriteLine("=>{0}", msgForCaller);
            Console.WriteLine("*************************************\n");
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

                if(10 == (MaxSpeed - CurrentSpeed) && listOfHandler != null) 
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
