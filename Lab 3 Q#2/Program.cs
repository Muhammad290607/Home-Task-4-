using System;

namespace Lab_Manual_3_Updated
{
    class Program
    {
        static string[,] ProductCatalog = new string[,]
        {
            {"PRD001", "Apple", "1.50", "15"},
            {"PRD002", "Banana", "0.75", "8"},
            {"PRD003", "Milk", "2.00", "5"},
            {"PRD004", "Bread", "1.25", "12"},
            {"PRD005", "Eggs", "3.50", "20"}
        };

        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Product Inventory System");
                Console.WriteLine("1. Show Inventory\n2. Find Most Expensive Product\n3. Find Cheapest Product\n4. Show Low Stock Items\n5. Modify Product Quantity\n6. Exit\nSelect an option:");
                Console.WriteLine("-------------------------------------");

                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        DisplayProducts();
                        break;
                    case 2:
                        FindMostExpensive();
                        break;
                    case 3:
                        FindCheapest();
                        break;
                    case 4:
                        ShowLowStock();
                        break;
                    case 5:
                        Console.WriteLine("Enter Product Code: ");
                        string productCode = Console.ReadLine();
                        Console.WriteLine("Enter Updated Quantity: ");
                        string newQuantity = Console.ReadLine();
                        UpdateStock(productCode, newQuantity);
                        break;
                    case 6:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void DisplayProducts()
        {
            Console.WriteLine("Product ID  |  Name  |  Price  |  Quantity");
            for (int i = 0; i < ProductCatalog.GetLength(0); i++)
            {
                Console.WriteLine($"{ProductCatalog[i, 0]}\t\t{ProductCatalog[i, 1]}\t\t{ProductCatalog[i, 2]}\t\t{ProductCatalog[i, 3]}");
            }
        }

        static void FindMostExpensive()
        {
            double maxCost = 0;
            int index = 0;
            for (int i = 0; i < ProductCatalog.GetLength(0); i++)
            {
                double price = Convert.ToDouble(ProductCatalog[i, 2]);
                if (price > maxCost)
                {
                    maxCost = price;
                    index = i;
                }
            }
            Console.WriteLine($"Most Expensive Product: {ProductCatalog[index, 1]} - ${ProductCatalog[index, 2]}");
        }

        static void FindCheapest()
        {
            double minCost = double.MaxValue;
            int index = 0;
            for (int i = 0; i < ProductCatalog.GetLength(0); i++)
            {
                double price = Convert.ToDouble(ProductCatalog[i, 2]);
                if (price < minCost)
                {
                    minCost = price;
                    index = i;
                }
            }
            Console.WriteLine($"Cheapest Product: {ProductCatalog[index, 1]} - ${ProductCatalog[index, 2]}");
        }

        static void ShowLowStock()
        {
            Console.WriteLine("Enter Minimum Stock Level: ");
            int minStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Product ID  |  Name  |  Price  |  Quantity");

            for (int i = 0; i < ProductCatalog.GetLength(0); i++)
            {
                int stock = Convert.ToInt32(ProductCatalog[i, 3]);
                if (stock < minStock)
                {
                    Console.WriteLine($"{ProductCatalog[i, 0]}\t\t{ProductCatalog[i, 1]}\t\t{ProductCatalog[i, 2]}\t\t{ProductCatalog[i, 3]}");
                }
            }
        }

        static void UpdateStock(string productID, string quantity)
        {
            for (int i = 0; i < ProductCatalog.GetLength(0); i++)
            {
                if (productID == ProductCatalog[i, 0])
                {
                    ProductCatalog[i, 3] = quantity;
                    Console.WriteLine("Quantity updated successfully.");
                    return;
                }
            }
            Console.WriteLine("Product not found.");
        }
    }
}