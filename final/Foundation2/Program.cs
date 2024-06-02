using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("3266 Henery Street", "Mulvane", "Kansas", "United States");
        Customer customer1 = new Customer("customer1", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Spring water", "PID1000", 3, 2));
        order1.AddProduct(new Product("Rice", "PID1001", 2, 5));

        Address address2 = new Address("Av. Pedro Simón Laplace 5637", "Córdoba", "Córdoba", "Argentina");
        Customer customer2 = new Customer("customer2", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Spring water", "PID1000", 3, 5));
        order2.AddProduct(new Product("Rice", "PID1001", 2, 1));
        order2.AddProduct(new Product("Alfajor", "PID1002", 1.5, 4));

        List<Order> orders = [order1, order2];
        int index = 1;
        foreach(Order order in orders)
        {
            Console.WriteLine($"Order: {index++}:\n\nPacking label: {order.GetPackingLabel()}.\nShipping label: {order.GetShippingLabel()}.\nTotal price: {order.GetTotal()}\n\n\n");
        }        
    }
}