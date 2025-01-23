using ShoppingCart.Contracts;
using ShoppingCart.Domain;

namespace ShoppingCart.Services;

public class ProductList : IProductList
{
    // In "real life" this information would be better off stored in a database, with the product code being the primary key
    private readonly Dictionary<string, Product> _products = new()
    {
        { "A", new Product("A", 2.00m, new BulkDiscount() { Price = 7.00m, Quantity = 4 }) },
        { "B", new Product("B", 12.00m) },
        { "C", new Product("C", 1.25m, new BulkDiscount() { Price = 6.00m, Quantity = 6 }) },
        { "D", new Product("D", 0.15m) },
    };

    public Product GetByCode(string code)
    {
        if (!_products.TryGetValue(code, out var product))
        {
            throw new KeyNotFoundException($"Product with code {code} does not exist");
        }
        
        return product;
    }
}