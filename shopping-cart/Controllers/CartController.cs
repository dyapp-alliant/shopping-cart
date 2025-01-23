using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Contracts;
using ShoppingCart.Controllers.Requests;
using ShoppingCart.Controllers.Responses;

namespace ShoppingCart.Controllers;

[ApiController]
[Route("cart")]
public class CartController
{
    private readonly ITerminal _terminal;

    public CartController(ITerminal terminal)
    {
        _terminal = terminal;
    }

    [HttpPut(Name = "scan_item")]
    public ScanItemResponse ScanItem([FromBody] ScanItemRequest request)
    {
        var cart = _terminal.Scan(request.ItemCode);

        return new ScanItemResponse() { CartItems = cart };
    }

    [Route("checkout")]
    [HttpPost(Name = "checkout")]
    public decimal Checkout()
    {
        var total = _terminal.Total();
        _terminal.Clear();
        return total;
    }
}