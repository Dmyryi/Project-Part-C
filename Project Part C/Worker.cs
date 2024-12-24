using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public class Worker : Person
    {
        public override string FirstName { get; set; }

        public Worker(string firstName)
        {
            FirstName = firstName;

        }

        public override void Work()
        {
            Console.WriteLine($"{FirstName} is working.");
        }
    }
}
