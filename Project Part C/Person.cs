using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public abstract class Person
    {
        public abstract string FirstName { get; set; }


        public abstract void Work();

        public override string ToString()
        {
            return $"{FirstName}";
        }
    }
}
