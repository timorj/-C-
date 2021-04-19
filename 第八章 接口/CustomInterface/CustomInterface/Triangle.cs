using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Triangle : Shape, IPointy
    {
        public Triangle()
        {

        }
        public Triangle(string name):base(name)
        {
        }
        public byte Points => 3;

        public override void Draw()
        {
            Console.WriteLine("Draw {0} the Triangle", PetName);
        }

    }
}
