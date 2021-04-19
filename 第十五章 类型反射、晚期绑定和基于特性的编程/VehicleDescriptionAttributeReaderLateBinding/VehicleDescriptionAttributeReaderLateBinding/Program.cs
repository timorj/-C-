using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Value of VehicleDescriptionAttribute*****\n");
            ReflectAttributesUsingLateBinding();
            Console.ReadLine();
        }
        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                Assembly asm = Assembly.Load("AttributedCarLibrary");

                Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");

                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");

                Type[] types = asm.GetTypes();

                foreach (Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDesc, false);

                    foreach (object o in objs)
                    {
                        Console.WriteLine("->{0}:{1}", t.Name, propDesc.GetValue(o, null));
                    }
                }
                }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
