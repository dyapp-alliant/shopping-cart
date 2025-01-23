using ShoppingCart.Domain;

namespace ShoppingCart.Contracts;

public interface IProductList
{
    public Product GetByCode(string code);
}