using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    [Serializable]
    [Obsolete]
    class MotorCycle
    {
        [NonSerialized]
        float weightOfCurrentPassengers;

        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
