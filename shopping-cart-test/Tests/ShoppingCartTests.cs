using ShoppingCart.Services;

namespace ShoppingCart.Test;

// In a "real" project, I would break these tests up by file to test each individual class
// However, here, I am putting it in one file for simplicity, as the ask was just to test the calculation logic
public class ShoppingCartTests
{
    public static TheoryData<string, decimal> TestCases = new()
    {
        {"ABCDABAA", 32.40m },
        {"CCCCCCC", 7.25m},
        {"ABCD", 15.40m}
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void CalculatePrice_Success(string cartItems, decimal expectedValue)
    {
        // Would normally use the interface for IProductList (for example, if it were a database),
        // and use NSubstitute or a similar library to mock it. However, here, the product list is 
        // defined explicitly as a dictionary, so it's easier to use the concrete implementation
        var service = new Terminal(new ProductList());

        foreach (var item in cartItems)
        {
            service.Scan(item.ToString());
        }

        Assert.Equal(service.Total(), expectedValue);
    }
}