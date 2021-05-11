using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacesw
{
    interface IEat
    {
        void eat();
    }
    interface IWork
    {
        void work();
    }
    interface ISleep
    {
        void sleep();
    }

    class Guy : IEat, IWork, ISleep
    {
        public void eat()
        {
            Console.WriteLine("Nyam Nyam");
        }
        public void work()
        {
            Console.WriteLine("hugh");
        }
        public void sleep()
        {
            Console.WriteLine("zzzzzzzz");
        }
    }

    class Robot : IWork
    {
        public void work()
        {
            Console.WriteLine("ROB ROB ROB");
        }
    }


}
