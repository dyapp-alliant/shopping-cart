# Shopping Cart API

This API has three endpoints:

## PUT /cart

This endpoint takes in a body in the following format

```
{
    "itemCode": "A"
}
```

It returns the list of items currently in the cart.

This endpoint will throw an error if the product code provided is not found in the list of available products.

## POST /cart/checkout

This endpoint returns the total price of all items scanned before it was called. This endpoint does not take in a body.

## DELETE /cart

This endpoint clears all items in the cart, and does not take in a body.
