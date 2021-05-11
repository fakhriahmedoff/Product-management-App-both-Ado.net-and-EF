using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacesw
{
    class Program
    {
        static void Main(string[] args)
        {
            //  InterfacesDemo();
            // MultipleImplementation();
            //idkwhat();
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new FileLogger();
            customerManager.Add();

            Console.ReadLine();
        }

        class CustomerManager
        {
            public  ILogger Logger { get; set; }
            public void Add()
            {
                Logger.Log();
            }
            

        }
        class Logger:ILogger
        {
           public void Log()
            {
                Console.WriteLine("Logged To deytabeys");
            }
        }
        class DatabaseLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logged to DB");
            }
        }
        class FileLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("Logggd to File");
            }
        }
      
        interface ILogger
        {
            void Log();
        }

        private static void idkwhat()
        {
            IWork[] workers = new IWork[2] {
             new Guy(),
            new Robot(),
            };
            foreach (var worker in workers)
            {
                worker.work();
            }
            IEat eater = new Guy();
            eater.eat();
        }

        private static void MultipleImplementation()
        {
            ICustomerDal[] customerDals = new ICustomerDal[3] {
            new SqlServerCustomerDal(),
            new OracleServerCustomerDal(),
            new MysqlCustomerServerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }
        }

        private static void InterfacesDemo()
        {
            PersonManager personManager = new PersonManager();
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Faxri",
                Lastname = "Ahmadov",
                Address = "Shamaki"
            };
            Student student = new Student
            {
                Id = 1,
                FirstName = "Mahmud",
                Lastname = "Kelenterof",
                Department = "Shamaki"
            };
            personManager.Add(customer);
            personManager.Add(student);
        }
    }
    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string Lastname { get; set; }
    }

    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
    }
    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
    }

    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine("Adi" + person.FirstName);
            Console.WriteLine("Soyadi" + person.Lastname);
        }
    }


}
