using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionsMultipleParams
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMath simpleMath = new SimpleMath();

            SimpleMath.MathMessage mathMessage = new SimpleMath.MathMessage((m, i) =>
            {
                Console.WriteLine(m);
                Console.WriteLine("The result is:{0}", i);
            });
            simpleMath.SetMathMessage(mathMessage);
            simpleMath.MathAdd(2, 2);
        }
    }

    class SimpleMath
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage mathMessage;
       
        public void SetMathMessage(MathMessage mathMessage)
        {
            this.mathMessage = mathMessage;
        }

        public void MathAdd(int x, int y) 
        {
            if(mathMessage != null) 
            {
                mathMessage("Adding has completed!", x + y);
            }
        }
    }
}
