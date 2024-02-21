using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Product product1 = new Product("Black Pen", "P121", 10.0, 3);
        Product product2 = new Product("Water Cup", "P122", 15.0, 2);
        Product product3 = new Product("Notebook", "P123", 8.0, 5);
        Product product4 = new Product("Pencil", "P124", 4.5, 4);
        Product product5 = new Product("bag", "P125", 24.5,2);

        Address address1 = new Address("123 Main St", "City1", "State1", "USA");
        Customer customer1 = new Customer("Toreto ", address1);

        Address address2 = new Address("456 Oak St", "City2", "State2", "Canada");
        Customer customer2 = new Customer("Bryan Johnson", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product4);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);
        order2.AddProduct(product2);
        order2.AddProduct(product3);
        order2.AddProduct(product5);

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Order Details:");
        Console.WriteLine($"Packing Label:\n{order.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{order.GetShippingLabel()}");
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost()}\n");
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    public Customer Customer { get; private set; }

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.CalculateTotalCost();
        }
        totalCost += Customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Products in the Order:\n";
        foreach (Product product in products)
        {
            packingLabel += $"{product.Name} ({product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Customer: {Customer.Name}\n{Customer.Address.GetFormattedAddress()}";
    }
}

class Product
{
    public string Name { get; private set; }
    public string ProductId { get; private set; }
    public double PricePerUnit { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public double CalculateTotalCost()
    {
        return PricePerUnit * Quantity;
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string StateProvince { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string stateProvince, string country)
    {
        Street = street;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country == "USA";
    }

    public string GetFormattedAddress()
    {
        return $"{Street}\n{City}, {StateProvince}\n{Country}";
    }
}
