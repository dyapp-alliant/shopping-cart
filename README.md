# Shopping Cart API

This API has two endpoints:

## PUT /cart

This endpoint takes in a body in the following format

```
{
    "itemCode": "A"
}
```

This endpoint will throw an error if the product code provided is not found in the list of available products.

## POST /cart/checkout

This endpoint clears the cart and returns the total price of all items scanned before it was called. This endpoint does not take in a body.
