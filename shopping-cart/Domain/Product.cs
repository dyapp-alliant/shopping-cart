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

    public decimal CalculatePrice(int quantity)
    {
        if (BulkDiscount == null || quantity < BulkDiscount.Quantity)
        {
            return quantity * Price;
        }

        var bulk = quantity / BulkDiscount.Quantity;
        var remaining = quantity % BulkDiscount.Quantity;
        return (bulk * BulkDiscount.Price) + (remaining * Price);
    }

    // Overriding equality operators so I can use Product class as dictionary key
    public override bool Equals(object? obj)
    {
        return Equals(obj as Product);
    }

    public bool Equals(Product? other)
    {
        return other != null && Code == other.Code;
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}

public class BulkDiscount
{
    public int Quantity { get; set;}
    public decimal Price { get; set;}
}