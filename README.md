# Inventory Management System (C#)

A simple console-based inventory management application built in C#. Users can add new products, update stock levels, view the full inventory, and remove products — all through a menu-driven interface.

## Features

- **Add Product** — Enter a name, price, and quantity to add a new product. Duplicate product names are detected and rejected. Price must be greater than 0; quantity must be zero or positive.
- **Update Stock** — Restock (increase) or sell (decrease) the quantity of an existing product. Selling more than the available stock is blocked with an error message.
- **View Products** — Displays every product currently in inventory, including name, price, and quantity.
- **Remove Product** — Look up a product by name, view its details, and confirm before deleting it from inventory.

## How It Works

The application runs in a loop, displaying a numbered menu until the user chooses to exit:
-1.Add a product
-2.Update stock
-3.View products
-4.Remove a product
-5.Exit
All product data is stored in memory using a `List<Product>` for the duration of the session (no persistence to disk).

## Project Structure

- `Product` — a class representing a single inventory item (name, price, quantity), with both a parameterized and a default constructor.
- `FindProduct` — a shared helper method used across Add, Update, and Remove operations to locate a product by name, returning its index in the list (or `-1` if not found).
- `AddProduct`, `UpdateStock`, `DisplayInventory`, `RemoveProduct` — the four core operations, each validating input before modifying the inventory.

## Known Limitations

- Numeric input is read using `int.Parse` / `double.Parse`, so entering non-numeric text at a prompt will cause the program to throw an exception and exit rather than showing a friendly error. Switching these to `TryParse` is a planned improvement.
- Data does not persist between runs — the inventory resets each time the program starts.

## Requirements

- .NET SDK (any recent version)

## Running It

```bash
dotnet run
```
