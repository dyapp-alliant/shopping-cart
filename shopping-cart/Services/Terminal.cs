using ShoppingCart.Contracts;
using ShoppingCart.Domain;

namespace ShoppingCart.Services;

public class Terminal : ITerminal
{
    private readonly IProductList _products;

    public Terminal(IProductList products)
    {
        _products = products;
    }

    public void Scan(string item)
    {
        throw new NotImplementedException();
    }

    public decimal Total()
    {
        throw new NotImplementedException();
    }

    private decimal CalculatePrice(Product product, int quantity)
    {
        throw new NotImplementedException();
    }
}