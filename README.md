# Project-Part-C
ПОСТАНОВКА ЗАДАЧІ
Завдання:
1.	Додати використання делегатів (delegates) .NET (наприклад, Action, Predicate, Func, тощо), а також визначити і використати власний(і) делегат(и)*. *всього має бути продемонстровано роботу мінімум з трьома делегатами, один із яких є власним.
2.	Продемонструвати використаня подій (events)**. **не менше двох подій
3.	Якщо делегати або події були використані у методах, для яких у Part A були написані unit-тести, то перевірити проходження unitтестів.
4.	Виконати функціональне тестування основної програми.
5.	Оформити звіт:
•	Титульний аркуш
•	Завдання
•	Опис предметної області
•	Діаграма класів
•	Результати запуску unit-тестів.
•	Результати функціонального тестування
•	Програмний код класів
•	Програмний код основної програми 
ВИКОНАННЯ РОБОТИ
1)	Опис класу: 
a)	Перелічення(Enum):
PizzaName – перелік назв піц(Пепероні, Маргарита, Гавайська, 4 Сири, Діабо, Бір-бургер, Бренд шеф 
b)	Класи:
Pizzeria – клас для зберігання даних про піцерію
Person – абстрактний клас, що представляє основу для створення різних працівників.
Pizza – клас для оброблення кожної піци в замовлені
Order – клас для зберігання даних про замовлення в піцерії
Worker – клас для зберігання даних про робітників в піцерії
c)	Інтерфейс:
IInteraction – інтерфейс для змінення статусу та створення замовлення


![ Діаграма класів ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/1.png)

Рисунок 1 – Діаграма класів
 
![ Результат запуску unit-тестів ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/2.png)

Рисунок 2 – Результат запуску unit-тестів
 
![ Результат функціонального тестування №1 некоректний вибір в меню ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/3.png)

Рисунок 3 – Результат функціонального тестування №1 некоректний вибір в меню
 
![ Результат функціонального тестування №2 некоректні данні для створення торгової точки ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/4.png)

Результат 4 – Результат функціонального тестування №2 некоректні данні для створення торгової точки 
 
![ Результат функціонального тестування №3 створення торгової точки ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/5.png)

Рисунок 5 – Результат функціонального тестування №3 створення торгової точки
 
![ Результат функціонального тестування №4 некоректні данні створення нового співробітника ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/6.png)

Результат 6 – Результат функціонального тестування №4 некоректні данні створення нового співробітника 
 
![ Результат функціонального тестування №5 створення нового співробітника ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/7.png)

Результат 7 – Результат функціонального тестування №5 створення нового співробітника
 
![ Результат функціонального тестування №6 некоректне створення нового замовлення ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/8.png)

Результат 8 – Результат функціонального тестування №6 некоректне створення нового замовлення
 
![ Результат функціонального тестування №7 створення нового замовлення ](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/9.png)

Результат 9 – Результат функціонального тестування №7 створення нового замовлення
 
![ Результат функціонального тестування №8 перегляд замовлення на конкретній точці](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/10.png)

Результат 10 – Результат функціонального тестування №8 перегляд замовлення на конкретній точці
 
![ Результат функціонального тестування №9 перегляд працівників на конкретній точці](https://github.com/Dmyryi/Project-Part-C/blob/main/Part%20C/11.png)

Результат 11 – Результат функціонального тестування №9 перегляд працівників на конкретній точці

 Посилання на Github:https://github.com/Dmyryi/Project-Part-C


ДОДАТОК
Лістинг програми


Вміст консольного додатку (Pizzeria.cs):
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
Вміст класу консольного додатку (Worker.cs):
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
Вміст консольного додатку (Order.cs):
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
Вміст консольного додатку (Pizza.cs):
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public class Pizza : IComparable<Pizza>, ICloneable
    {
        public PizzaName Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        public Pizza(PizzaName name, string size, decimal price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public int CompareTo(Pizza other)
        {
            return Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            return new Pizza(Name, Size, Price);
        }
    }

}
Вміст консольного додатку(IInteraction.cs)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public interface IInteraction
    {
        void Create();
        void Process();
    }
}
Вміст кольного додатку(PizzaName.cs)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Part_C
{
    public enum PizzaName
    {
        Margherita,
        Pepperoni,
        Hawaiian,
        FourCheese,
        Diablo
    }
}
Вміст консольного додатку(Person.cs)
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

Вміст консольного додатку(Program.cs)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project_Part_C
{

    public delegate void OrderStatusChangeHandler(string message);
    internal class Program
    {

        static List<Pizzeria> pizzerias = new List<Pizzeria>();

        // Стандартний делегат Action для виведення повідомлень
        public static Action<string> PrintMessage = message => Console.WriteLine(message);

        // Стандартний делегат Func для обчислення ціни замовлення
        public static Func<List<Pizza>, decimal> CalculateTotalPrice = pizzas =>
        {
            return pizzas.Sum(pizza => pizza.Price);
        };
        
      
        // Події для обробки замовлення та створення
        public static event OrderStatusChangeHandler OrderCreated;
        public static event OrderStatusChangeHandler OrderProcessed;
        static void Main(string[] args)
        {
            OrderCreated += message => PrintMessage(message); 
            OrderProcessed += message => PrintMessage(message);

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Створити або вибрати піцерію");
                Console.WriteLine("2. Додати працівників");
                Console.WriteLine("3. Створити і обробити замовлення");
                Console.WriteLine("4. Показати замовлення");
                Console.WriteLine("5. Показати працівників");
                Console.WriteLine("6. Завершити роботу");

                Console.Write("Оберіть опцію: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateOrSelectPizzeria();
                        break;

                    case "2":
                        AddEmployees();
                        break;

                    case "3":
                        CreateAndProcessOrder();
                        break;

                    case "4":
                        ShowOrders();
                        break;

                    case "5":
                        ShowEmployees();
                        break;

                    case "6":
                        Console.WriteLine("Завершення роботи... До побачення!");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
                Console.WriteLine();
            }
        }



        // Метод для создания или выбора пиццерии
        static bool CreateOrSelectPizzeria()
        {
            if (pizzerias.Count == 0)
            {
                while (true)
                {
                    PrintMessage("Введіть деталі піцерії (ім'я, адреса):");
                    string input = Console.ReadLine();

                    if (Pizzeria.TryParse(input, out Pizzeria newProd))
                    {
                        pizzerias.Add(newProd);
                        PrintMessage("Піцерія створена.");
                        return true;
                    }
                    else
                    {
                        PrintMessage("Помилка вводу даних піцерії. Спробуйте ще раз.");
                    }

                }
            }
            else
            {
                PrintMessage("Виберіть піцерію зі списку:");
                for (int i = 0; i < pizzerias.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {pizzerias[i].Name} - {pizzerias[i].Address}");
                }

                int selectedPizzeriaIndex;
                if (int.TryParse(Console.ReadLine(), out selectedPizzeriaIndex) && selectedPizzeriaIndex >= 1 && selectedPizzeriaIndex <= pizzerias.Count)
                {
                    var selectedPizzeria = pizzerias[selectedPizzeriaIndex - 1];
                    PrintMessage($"Ви вибрали піцерію: {selectedPizzeria.Name} на {selectedPizzeria.Address}");
                }
                else
                {
                    PrintMessage("Невірний вибір.");
                }
            }
            return true;
        }

        // Метод для добавления работников
        private static void AddEmployees()
        {
            if (pizzerias.Count == 0)
            {
                PrintMessage("Спочатку потрібно створити піцерію.");
                return;
            }

            PrintMessage("Оберіть піцерію, для якої додається працівник:");
            for (int i = 0; i < pizzerias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pizzerias[i].Name} - {pizzerias[i].Address}");
            }

            int selectedPizzeriaIndex;
            if (!int.TryParse(Console.ReadLine(), out selectedPizzeriaIndex) || selectedPizzeriaIndex < 1 || selectedPizzeriaIndex > pizzerias.Count)
            {
                PrintMessage("Невірний вибір.");
                return;
            }

            var selectedPizzeria = pizzerias[selectedPizzeriaIndex - 1];

            while (true)
            {
                try
                {
                    string firstName = GetWorkerFirstName();


                    Worker worker = new Worker(firstName);
                    selectedPizzeria.Workers.Add(worker);
                    PrintMessage("Працівника додано.");
                    break;
                }
                catch (ArgumentException ex)
                {
                    PrintMessage($"Помилка: {ex.Message}. Спробуйте ще раз.");
                }
            }
        }

        // Метод для создания и обработки заказа
        private static void CreateAndProcessOrder()
        {
            if (pizzerias.Count == 0)
            {
                PrintMessage("Спочатку потрібно створити піцерію.");
                return;
            }

            PrintMessage("Оберіть піцерію, для якої створюється замовлення:");
            for (int i = 0; i < pizzerias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pizzerias[i].Name} - {pizzerias[i].Address}");
            }

            int selectedPizzeriaIndex;
            if (!int.TryParse(Console.ReadLine(), out selectedPizzeriaIndex) || selectedPizzeriaIndex < 1 || selectedPizzeriaIndex > pizzerias.Count)
            {
                PrintMessage("Невірний вибір.");
                return;
            }

            var selectedPizzeria = pizzerias[selectedPizzeriaIndex - 1];

            if (selectedPizzeria.Workers.Count == 0)
            {
                PrintMessage("Додайте хоча б одного працівника, перш ніж створювати замовлення.");
                return;
            }

            while (true)
            {
                try
                {
                    var orderNumber = selectedPizzeria.GenerateOrderNumber();
                    var order = new Order(orderNumber, "Очікується");

                    int pizzaCount = GetPizzaCount();

                    for (int i = 0; i < pizzaCount; i++)
                    {
                        PrintMessage($"Додавання піци {i + 1} із {pizzaCount}:");
                        var pizzaName = GetPizzaName();
                        var size = GetPizzaSize();


                        if (!selectedPizzeria.PizzaPrices.TryGetValue(pizzaName, out var price))
                        {
                            throw new ArgumentException("Ціна для цієї піци не знайдена. Спробуйте ще раз.");
                        }

                        var pizza = new Pizza(pizzaName, size, price);
                        order.AddPizza(pizza);
                        PrintMessage("Піца додана до замовлення.");
                    }

                    selectedPizzeria.CreateOrder(order);
                    order.Process();

                    // Викликаємо події
                    OrderCreated?.Invoke($"Замовлення #{order.Number} було створено.");
                    OrderProcessed?.Invoke($"Замовлення #{order.Number} було оброблено.");

                    //PrintMessage("Замовлення створено і оброблено.");
                    break;
                }
                catch (Exception ex)
                {
                    PrintMessage($"Помилка: {ex.Message}. Спробуйте ще раз.");
                }
            }
        }


        // Метод для отображения заказов
        private static void ShowOrders()
        {
            if (pizzerias.Count == 0)
            {
                PrintMessage("Спочатку потрібно створити піцерію.");
                return;
            }

            PrintMessage("Оберіть піцерію для перегляду замовлень:");
            for (int i = 0; i < pizzerias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pizzerias[i].Name} - {pizzerias[i].Address}");
            }

            int selectedPizzeriaIndex;
            if (!int.TryParse(Console.ReadLine(), out selectedPizzeriaIndex) || selectedPizzeriaIndex < 1 || selectedPizzeriaIndex > pizzerias.Count)
            {
                PrintMessage("Невірний вибір.");
                return;
            }

            var selectedPizzeria = pizzerias[selectedPizzeriaIndex - 1];

            if (selectedPizzeria.Orders.Count == 0)
            {
                PrintMessage("Замовлень немає.");
            }
            else
            {
                PrintMessage("Список замовлень:");
                foreach (var o in selectedPizzeria.Orders)
                {
                    PrintMessage($"Замовлення #{o.Number}: {o.Status}, кількість піц: {o.Pizzas.Count}");
                    foreach (var pizza in o.Pizzas)
                    {
                        Console.WriteLine($" - {pizza.Name} ({pizza.Size}) - {pizza.Price:C}");
                    }
                }
            }
        }

        // Метод для отображения сотрудников
        private static void ShowEmployees()
        {
            if (pizzerias.Count == 0)
            {
                Console.WriteLine("Спочатку потрібно створити піцерію.");
                return;
            }

            Console.WriteLine("Оберіть піцерію для перегляду працівників:");
            for (int i = 0; i < pizzerias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pizzerias[i].Name} - {pizzerias[i].Address}");
            }

            int selectedPizzeriaIndex;
            if (!int.TryParse(Console.ReadLine(), out selectedPizzeriaIndex) || selectedPizzeriaIndex < 1 || selectedPizzeriaIndex > pizzerias.Count)
            {
                Console.WriteLine("Невірний вибір.");
                return;
            }

            var selectedPizzeria = pizzerias[selectedPizzeriaIndex - 1];

            if (selectedPizzeria.Workers.Count == 0)
            {
                Console.WriteLine("У цієї піццерії немає працівників.");
            }
            else
            {
                Console.WriteLine("Список працівників:");
                foreach (var worker in selectedPizzeria.Workers)
                {
                    Console.WriteLine($"{worker.FirstName}");
                }
            }
        }

        // Метод для ввода данных: имя сотрудника
        private static string GetWorkerFirstName()
        {
            Console.Write("Введіть ім'я працівника: ");
            while (true)
            {
                string firstName = Console.ReadLine();

                // Проверка на пустоту или длину меньше 3 символов
                if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                    throw new ArgumentException("Ім'я співробітника не може бути порожнім або менше 3 букв!");

                // Проверка на наличие цифр
                if (Regex.IsMatch(firstName, @"\d"))
                    throw new ArgumentException("я співробітника не може містити цифри!");

                return firstName;
            }
        }


        // Метод для ввода данных: количество пицц в заказе
        private static int GetPizzaCount()
        {
            Console.WriteLine("Скільки піц Ви бажаєте додати?");
            int pizzaCount;
            while (!int.TryParse(Console.ReadLine(), out pizzaCount) || pizzaCount <= 0)
            {
                Console.WriteLine("Некоректна кількість. Спробуйте ще раз.");
            }
            return pizzaCount;
        }

        // Метод для выбора пиццы
        private static PizzaName GetPizzaName()
        {
            Console.WriteLine("Меню піц:");
            var pizzaList = Enum.GetValues(typeof(PizzaName)).Cast<PizzaName>().ToList();
            for (int j = 0; j < pizzaList.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {pizzaList[j]}");
            }

            int pizzaChoice;
            while (!int.TryParse(Console.ReadLine(), out pizzaChoice) || pizzaChoice < 1 || pizzaChoice > pizzaList.Count)
            {
                Console.WriteLine("Неправильний вибір піци. Спробуйте ще раз.");
            }

            return pizzaList[pizzaChoice - 1];
        }

        // Метод для ввода данных: размер пиццы
        private static string GetPizzaSize()
        {
            Console.Write("Введіть розмір (Small, Medium, Large): ");
            string size;
            while ((size = Console.ReadLine()) != "Small" && size != "Medium" && size != "Large")
            {
                Console.WriteLine("Невірний розмір. Спробуйте ще раз.");
            }
            return size;
        }
    }
}
