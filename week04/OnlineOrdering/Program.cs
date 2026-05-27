using System;

class Program
{
    static void Main(string[] args)
    {
        // Pedido 1: Cliente en USA
        Address address1 = new Address("123 Maple Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        
        order1.AddProduct(new Product("Laptop", "LPT-001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MOU-045", 25.50, 2));

        // Pedido 2: Cliente Internacional
        Address address2 = new Address("Carrera 45 # 12-34", "Bogotá", "Cundinamarca", "Colombia");
        Customer customer2 = new Customer("Maria Gomez", address2);
        Order order2 = new Order(customer2);
        
        order2.AddProduct(new Product("Desk Lamp", "LMP-88", 45.00, 1));
        order2.AddProduct(new Product("Mechanical Keyboard", "KBD-909", 120.00, 1));
        order2.AddProduct(new Product("Monitor", "MNT-27", 300.00, 2));

        // Visualización Pedido 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():0.00}\n");
        Console.WriteLine(new string('=', 40) + "\n");

        // Visualización Pedido 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():0.00}\n");
    }
}