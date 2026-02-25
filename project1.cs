using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();

        stock.Add("Milk", 10);
        stock.Add("Bread", 5);
        stock.Add("Apple", 20);

        PrintStock(stock);

        AddOrIncrease(stock, "Milk", 3);
        AddOrIncrease(stock, "Banana", 7);

        TrySell(stock, "Apple", 5);
        TrySell(stock, "Apple", 500);
        TrySell(stock, "Cheese", 1);

        RemoveProduct(stock, "Bread");
        RemoveProduct(stock, "Bread");

        Console.WriteLine();
        PrintStock(stock);

        // Ryhmittely
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();
        AddToCategory(categories, "Dairy", "Milk");
        AddToCategory(categories, "Fruit", "Apple");
        AddToCategory(categories, "Fruit", "Banana");

        Console.WriteLine();
        PrintCategories(categories);
    }

    static void PrintStock(Dictionary<string, int> stock)
    {
        foreach (var pair in stock)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }

    static void AddOrIncrease(Dictionary<string, int> stock, string name, int amount)
    {
        if (stock.ContainsKey(name))
        {
            stock[name] = stock[name] + amount;
        }
        else
        {
            stock.Add(name, amount);
        }
    }

    static void TrySell(Dictionary<string, int> stock, string name, int amount)
    {
        if (stock.TryGetValue(name, out int currentStock))
        {
            if (currentStock < amount)
            {
                Console.WriteLine("Not enough stock");
            }
            else
            {
                stock[name] = currentStock - amount;
                Console.WriteLine("Sold");
            }
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }

    static void RemoveProduct(Dictionary<string, int> stock, string name)
    {
        // TODO: Remove + tulostus

        if (stock.Remove(name))
        {
            Console.WriteLine("Removed ");
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }

    static void AddToCategory(Dictionary<string, List<string>> categories, string category, string product)
    {
        // TODO: ContainsKey/TryGetValue + lista

        if (!categories.ContainsKey(category))
        {
            categories.Add(category, new List<string>());
        }
        categories[category].Add(product);
    }

    static void PrintCategories(Dictionary<string, List<string>> categories)
    {
        foreach (var pair in categories)
        {
            Console.WriteLine(pair.Key + ":");
            foreach (var product in pair.Value)
            {
                Console.WriteLine(" - " + product);
            }
        }
    }
}
