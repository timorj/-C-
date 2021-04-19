using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace ObjectContextApp
{
    class SportsCar
    {

        public SportsCar()
        {
            Context context = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), context.ContextID);
            foreach (IContextProperty itfCtxProp in context.ContextProperties)
            {
                Console.WriteLine("-> Context Property:{0}", itfCtxProp.Name);
            }
        }
    }
    [Synchronization]
    class SportsCarTS:ContextBoundObject
    {
        public SportsCarTS()
        {
            Context context = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), context.ContextID);
            foreach (IContextProperty itfCtxProp in context.ContextProperties)
            {
                Console.WriteLine("-> Context Property:{0}", itfCtxProp.Name);
            }
        }
    }
}
