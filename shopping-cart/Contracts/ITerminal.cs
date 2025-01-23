namespace ShoppingCart.Contracts;

public interface ITerminal
{
    Dictionary<string, int> Scan(string item);
    decimal Total();
    void Clear();
}