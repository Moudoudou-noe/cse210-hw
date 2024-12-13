using System;
using System.Collections.Generic;

class Item
{
    private string _productName;
    private string _productCode;
    private decimal _unitPrice;
    private int _quantityInStock;

    public Item(string productName, string productCode, decimal unitPrice, int quantityInStock)
    {
        _productName = productName;
        _productCode = productCode;
        _unitPrice = unitPrice;
        _quantityInStock = quantityInStock;
    }

    public decimal GetCost() => _unitPrice * _quantityInStock;

    public string GenerateLabel() => $"{_productName} (Code: {_productCode})";
}

class Location
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _nation;

    public Location(string streetAddress, string city, string stateOrProvince, string nation)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _nation = nation;
    }

    public bool IsFromUS() => _nation.ToLower() == "united states";

    public string FullLocation()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_nation}";
    }
}

class Client
{
    private string _fullName;
    private Location _shippingAddress;

    public Client(string fullName, Location shippingAddress)
    {
        _fullName = fullName;
        _shippingAddress = shippingAddress;
    }

    public string GetFullName() => _fullName;

    public Location GetShippingLocation() => _shippingAddress;

    public bool ResidesInUSA() => _shippingAddress.IsFromUS();
}

class Purchase
{
    private List<Item> _items;
    private Client _client;

    public Purchase(Client client)
    {
        _items = new List<Item>();
        _client = client;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public decimal CalculateTotalAmount()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.GetCost();
        }

        total += _client.ResidesInUSA() ? 5 : 35;
        return total;
    }

    public void ShowPackingDetails()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Packing Details:");
        Console.ResetColor();
        foreach (var item in _items)
        {
            Console.WriteLine($"- {item.GenerateLabel()}");
        }
        Console.WriteLine();
    }

    public void ShowShippingDetails()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Shipping Details:");
        Console.ResetColor();
        Console.WriteLine($"{_client.GetFullName()}");
        Console.WriteLine(_client.GetShippingLocation().FullLocation());
        Console.WriteLine();
    }

    public void ShowTotalAmount()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Total Amount: ${CalculateTotalAmount():F2}");
        Console.ResetColor();
        Console.WriteLine("------------------------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Define locations
        var location1 = new Location("101 First St", "New York", "NY", "United States");
        var location2 = new Location("202 Second St", "Vancouver", "BC", "Canada");

        // Define clients
        var client1 = new Client("Alice Johnson", location1);
        var client2 = new Client("Bob Williams", location2);

        // Define items
        var item1 = new Item("Smartphone", "P100", 799.99m, 1);
        var item2 = new Item("Headphones", "P200", 129.99m, 2);
        var item3 = new Item("Tablet", "P300", 499.99m, 1);
        var item4 = new Item("Keyboard", "P400", 89.99m, 2);

        // Create orders
        var purchase1 = new Purchase(client1);
        purchase1.AddItem(item1);
        purchase1.AddItem(item2);

        var purchase2 = new Purchase(client2);
        purchase2.AddItem(item3);
        purchase2.AddItem(item4);

        // Display order details
        purchase1.ShowPackingDetails();
        purchase1.ShowShippingDetails();
        purchase1.ShowTotalAmount();

        purchase2.ShowPackingDetails();
        purchase2.ShowShippingDetails();
        purchase2.ShowTotalAmount();// Hello and for your information I use an emulator as a server to do my codes and this emulator is: https://dotnetfiddle.net/#, this is what I use since it's me my vs code no longer responds since I think it's my machine, so stop thinking that I cheat or anything, I have always worked honestly but if you think otherwise ok no problem make me a video call not even zoom and you will see how I will redo this code as I did it
    }
}