﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Circle DOES NOT override Draw().
    // If we did not implement the abstract Draw() method, Circle would also be
    // considered abstract, and would have to be marked abstract!
    class Circle : Shape
    {
        public Circle() { }
        public Circle( string name ) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", PetName);
        }
    }


    // Hexagon DOES override Draw().
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon( string name ) : base(name) { }

        public byte Points => 6;

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing hexagon in 3D!");
        }
    }

    // This class extends Circle and hides the inherited Draw() method.
    class ThreeDCircle : Circle, IDraw3D
    {
        // Hide the PetName property above me.
        public new string PetName { get; set; }

        // Hide any Draw() implementation above me.
        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circle");
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing Circle in 3D!");
        }
    }
}
