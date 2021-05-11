using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mess
{
    class Program
    {
        static void Main(string[] args)
        {
            //list();
            HandleException(() => {
                Find();
            });
           

            Console.ReadLine();
        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        private static void Find()
        {
            string[] cities = new string[3] { "mamhim", "salma", "kele" };
            if (!cities.Contains("salmaa"))
            {
                throw new RecordNotFoundException("Databasede belə bişey tapılmadı");
            }
            else
            {

            }
        }

        private static void list()
        {
            List<Customer> customers = new List<Customer>
            {
             new Customer {Id=1, Name="FAXRI" },
            new Customer { Id = 2, Name = "Mehmud" },
            };

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
        }
    }
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
