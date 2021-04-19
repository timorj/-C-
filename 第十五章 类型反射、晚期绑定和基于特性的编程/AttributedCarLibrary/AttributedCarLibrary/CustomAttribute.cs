using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//使得程序集下的公共类型符合CLS规范
[assembly:CLSCompliant(true)]
namespace AttributedCarLibrary
{
    [AttributeUsage( AttributeTargets.Class|AttributeTargets.Struct, Inherited =false)]
    public sealed class VehicleDescriptionAttribute:System.Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicleDescription)
        {
            Description = vehicleDescription;
        }
        public VehicleDescriptionAttribute()
        {

        }
    }
    [Serializable]
    [VehicleDescription(Description ="My rocking Harley")]
    public class Motorcycle
    {

    }
    [Serializable]
    [Obsolete("Use another vehicle")]
    [VehicleDescription(Description ="the old gray mare, she ain't what used be ...")]
    public class HorseAndBuggy
    {

    }
    [VehicleDescription("A very long, slow , but feature-rich auto")]
    public class Winnebago
    {

    }
}
