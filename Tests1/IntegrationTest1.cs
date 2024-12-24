using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Part_C;



namespace Project_Part_Ñ.Tests
{
    [TestClass]
    public class PizzeriaTests
    {
        [TestMethod]
        public void Pizzeria_Creation_With_Valid_Name_And_Address_Should_Succeed()
        {
            // Arrange
            var name = "Test Pizzeria";
            var address = "123 Main St";

            // Act
            var pizzeria = new Pizzeria(name, address);

            // Assert
            Assert.AreEqual(name, pizzeria.Name);
            Assert.AreEqual(address, pizzeria.Address);
        }

        [TestMethod]
        public void Pizzeria_Creation_With_Invalid_Name_Should_ThrowException()
        {
            // Arrange
            var invalidName = "A";
            var address = "123 Main St";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Pizzeria(invalidName, address));
        }

        [TestMethod]
        public void AddEmployee_Should_Add_Worker_To_Workers_List()
        {
            // Arrange
            var pizzeria = new Pizzeria("Pizzeria Test", "123 Main St");
            var worker = new Worker("John");

            // Act
            pizzeria.AddEmployee(worker);

            // Assert
            CollectionAssert.Contains(pizzeria.Workers, worker);
        }

        [TestMethod]
        public void AddEmployee_NullWorker_Should_ThrowException()
        {
            // Arrange
            var pizzeria = new Pizzeria("Pizzeria Test", "123 Main St");

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => pizzeria.AddEmployee(null));
        }

        [TestMethod]
        public void GenerateOrderNumber_Should_Return_Unique_Numbers()
        {
            // Arrange
            var pizzeria = new Pizzeria("Pizzeria Test", "123 Main St");

            // Act
            var order1 = pizzeria.GenerateOrderNumber();
            var order2 = pizzeria.GenerateOrderNumber();

            // Assert
            Assert.AreNotEqual(order1, order2);
        }
    }

    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_Creation_Should_Set_Properties()
        {
            // Arrange
            int number = 1;
            string status = "Pending";

            // Act
            var order = new Order(number, status);

            // Assert
            Assert.AreEqual(number, order.Number);
            Assert.AreEqual(status, order.Status);
        }

        [TestMethod]
        public void AddPizza_Should_Add_Pizza_To_Order()
        {
            // Arrange
            var order = new Order(1, "Pending");
            var pizza = new Pizza(PizzaName.Margherita, "Medium", 100);

            // Act
            order.AddPizza(pizza);

            // Assert
            CollectionAssert.Contains(order.Pizzas, pizza);
        }
    }

    [TestClass]
    public class PizzaTests
    {
        [TestMethod]
        public void Pizza_Clone_Should_Create_Identical_Copy()
        {
            // Arrange
            var pizza = new Pizza(PizzaName.Pepperoni, "Large", 120);

            // Act
            var clone = (Pizza)pizza.Clone();

            // Assert
            Assert.AreEqual(pizza.Name, clone.Name);
            Assert.AreEqual(pizza.Size, clone.Size);
            Assert.AreEqual(pizza.Price, clone.Price);
            Assert.AreNotSame(pizza, clone); // Ensure it's a different object
        }

        [TestMethod]
        public void Pizza_CompareTo_Should_Compare_By_Price()
        {
            // Arrange
            var pizza1 = new Pizza(PizzaName.Margherita, "Medium", 100);
            var pizza2 = new Pizza(PizzaName.Diablo, "Medium", 150);

            // Act
            int comparison = pizza1.CompareTo(pizza2);

            // Assert
            Assert.IsTrue(comparison < 0); // pizza1 is cheaper than pizza2
        }
    }

    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        public void Worker_Creation_Should_Set_FirstName()
        {
            // Arrange
            string firstName = "Alice";

            // Act
            var worker = new Worker(firstName);

            // Assert
            Assert.AreEqual(firstName, worker.FirstName);
        }
    }
}
