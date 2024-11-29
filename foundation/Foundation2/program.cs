using System;
using System.Collections.Generic;

class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost() => _price * _quantity;

    public string GetPackingLabel() => $"{_name} (ID: {_productId})";
}

class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA() => _country.ToLower() == "usa";

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;

    public Address GetAddress() => _address;

    public bool LivesInUSA() => _address.IsInUSA();
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public void DisplayPackingLabel()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Packing Label:");
        Console.ResetColor();
        foreach (var product in _products)
        {
            Console.WriteLine($"- {product.GetPackingLabel()}");
        }
        Console.WriteLine();
    }

    public void DisplayShippingLabel()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Shipping Label:");
        Console.ResetColor();
        Console.WriteLine($"{_customer.GetName()}");
        Console.WriteLine(_customer.GetAddress().GetFullAddress());
        Console.WriteLine();
    }

    public void DisplayTotalCost()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Total Cost: ${CalculateTotalCost():F2}");
        Console.ResetColor();
        Console.WriteLine("------------------------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        var address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        var address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create customers
        var customer1 = new Customer("John Doe", address1);
        var customer2 = new Customer("Jane Smith", address2);

        // Create products
        var product1 = new Product("Laptop", "A123", 999.99m, 1);
        var product2 = new Product("Mouse", "B456", 25.99m, 2);
        var product3 = new Product("Keyboard", "C789", 49.99m, 1);
        var product4 = new Product("Monitor", "D101", 199.99m, 1);

        // Create orders
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        order1.DisplayPackingLabel();
        order1.DisplayShippingLabel();
        order1.DisplayTotalCost();

        order2.DisplayPackingLabel();
        order2.DisplayShippingLabel();
        order2.DisplayTotalCost();
    }
}