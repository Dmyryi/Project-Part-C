using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public class Order : IInteraction, IEnumerable<Pizza>
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public Order(int number, string status)
        {
            Number = number;
            Status = status;
            Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }

        public void Create()
        {
            Console.WriteLine($"Order {Number} has been created.");
        }

        public void Process()
        {
            Console.WriteLine($"Order {Number} is being processed.");
        }

        public IEnumerator<Pizza> GetEnumerator()
        {
            return Pizzas.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
