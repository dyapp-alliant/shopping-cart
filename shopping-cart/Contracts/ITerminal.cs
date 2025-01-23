namespace ShoppingCart.Contracts;

public interface ITerminal
{
    void Scan(string item);
    decimal Total();
}