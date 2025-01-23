namespace ShoppingCart.Domain;

public class Product
{
    public string Code { get; set;}
    public decimal Price { get; set;}
    public BulkDiscount? BulkDiscount { get; set; }

    public Product(string code, decimal price, BulkDiscount? bulkDiscount = null)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Code cannot be null, empty, or whitespace.", nameof(code));
        }

        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
        }

        Code = code;
        Price = price;

        if (bulkDiscount != null) 
        {
            BulkDiscount = bulkDiscount;
        }
    }
}

public class BulkDiscount
{
    public int Quantity { get; set;}
    public decimal Price { get; set;}
}