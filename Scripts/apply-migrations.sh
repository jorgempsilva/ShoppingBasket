#!/bin/bash
dotnet ef --version || echo "dotnet-ef is not installed."
echo "Starting migrations..."
cd /src/ShoppingBasket || { echo "ShoppingBasket directory not found"; exit 1; }
echo "Current directory: $(pwd)"
echo "Running migrations..."
dotnet ef database update --project /src/Infrastructure/ --startup-project /src/ShoppingBasket/ --context SqlContext --verbose || { echo "Migrations failed"; exit 1; }
echo "Migrations applied successfully."