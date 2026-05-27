using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5.0 : 35.0;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product p in _products)
        {
            label += $"Product: {p.GetName()} | ID: {p.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"Name: {_customer.GetName()}\n";
        label += $"Address:\n{_customer.GetAddress().GetFullAddress()}";
        return label;
    }
}