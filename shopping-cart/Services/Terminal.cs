using ShoppingCart.Contracts;
using ShoppingCart.Domain;

namespace ShoppingCart.Services;

public class Terminal : ITerminal
{
    private readonly IProductList _products;
    
    private Dictionary<Product, int> _scannedItems = [];

    public Terminal(IProductList products)
    {
        _products = products;
    }

    public Dictionary<string, int> Scan(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            throw new ArgumentNullException("Item code cannot be empty");
        }

        var product = _products.GetByCode(item);

        _scannedItems.TryGetValue(product, out int quantity);
        _scannedItems[product] = quantity + 1;

        return _scannedItems.ToDictionary(_ => _.Key.Code, _ => _.Value);
    }

    public decimal Total()
    {
        decimal total = 0.00m;

        foreach (var item in _scannedItems)
        {
            total += item.Key.CalculatePrice(item.Value);
        }

        return total;
    }

    public void Clear()
    {
        _scannedItems = [];
    }
}