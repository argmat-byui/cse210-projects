using System;
using System.Security.Cryptography;

class Order
{
    private List<Product> _products = [];
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotal()
    {
        double total = GetShippingCost();
        foreach(Product product in _products)
        {
            total += product.GetTotalCost();
        }
        return total;
    }

    private double GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5 : 35;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach(Product product in _products)
        {
            packingLabel += $"({product.GetName()}-{product.GetProductId()})";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} - {_customer.GetAddressStringRepresentation()}";
    }
}