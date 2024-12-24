using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public class Pizzeria
    {
        private int _nextOrderNumber = 1;
        private string _name;
        private string _address;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                    throw new ArgumentException("Ім'я піцерії не може бути порожнім або менше 3 символів!");
                _name = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                    throw new ArgumentException("Адреса піцерії не може бути порожньою або менше 3 символів!");
                _address = value;
            }
        }

        public List<Worker> Workers { get; } = new List<Worker>();
        public List<Order> Orders { get; } = new List<Order>();

        public Dictionary<PizzaName, decimal> PizzaPrices { get; } = new Dictionary<PizzaName, decimal>
        {
            { PizzaName.Margherita, 100 },
            { PizzaName.Pepperoni, 120 },
            { PizzaName.Hawaiian, 110 },
            { PizzaName.FourCheese, 140 },
            { PizzaName.Diablo, 150 }
        };

        public Pizzeria()
        {
            Name = "034";
            Address = "Тестова піцерія";
        }

        public Pizzeria(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int GenerateOrderNumber()
        {
            return _nextOrderNumber++;
        }

        public void AddEmployee(Worker worker)
        {
            if (worker == null)
                throw new ArgumentNullException(nameof(worker), "Worker cannot be null.");
            Workers.Add(worker);
        }

        public void CreateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            Orders.Add(order);
        }


        public static Pizzeria Parse(string s)
        {
            string[] parts = s.Split(',');
            if (parts.Length != 2)
                throw new FormatException("Некоректний формат рядка: очікується 2 частинb, розділених символом ';'.");

            try
            {
                string name = parts[0];
                if (string.IsNullOrWhiteSpace(name))
                    throw new FormatException("Назва продукту не може бути порожньою або складатися лише з пробілів.");
                string address = parts[1];
                if (string.IsNullOrWhiteSpace(name))
                    throw new FormatException("Назва продукту не може бути порожньою або складатися лише з пробілів.");
                return new Pizzeria(name, address);
            }
            catch (Exception ex)
            {
                throw new FormatException("Помилка під час перетворення рядка в Product.", ex);
            }
        }



        public static bool TryParse(string s, out Pizzeria obj)
        {
            try
            {
                obj = Parse(s);
                return true;
            }
            catch
            {
                obj = null; return false;
            }
        }

    }
}
