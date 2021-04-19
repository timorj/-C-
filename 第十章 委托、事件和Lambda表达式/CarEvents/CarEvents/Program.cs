using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Fun with events*******");
            Car c1 = new Car("Slug slug", 100, 10);

            int aboutToBlowCount = 0;

            c1.AboutToBlow += CarIsAlmostDoomed;

            c1.Exploded += CarExploded;

            //匿名方法
            c1.AboutToBlow += (sender, e) =>
            {
                aboutToBlowCount++;
                Console.WriteLine("Eek! Going too fast!");
            };
            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCount++;
                Console.WriteLine("{0} say: {1}", ((Car)sender).PetName, e.msg);
            };

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.WriteLine("AboutToBlow event was fired {0} times", aboutToBlowCount);
            Console.ReadKey();

        }

        private static void CarExploded(object sender, CarEventArgs e)
        {
            Console.WriteLine("{0} says:{1}", ((Car)sender).PetName, e.msg);
        }

        private static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            Console.WriteLine("{0} says:{1}",((Car)sender).PetName, e.msg);
        }
    }
    public class CarEventArgs : EventArgs 
    {
        public readonly string msg;
        public CarEventArgs(string msg)
        {
            this.msg = msg;
        }
    }
    public class Car
    {
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        
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
                if (Exploded != null)
                {
                    Exploded(this, new CarEventArgs("Sorry, this Car is dead..."));
                }
            }
            else
            {
                CurrentSpeed += delta;

                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    if (AboutToBlow!=null)
                    {
                        AboutToBlow(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                    }
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
