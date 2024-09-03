using System;
using System.Collections.Generic;

namespace GildedRoseKata.Services;

public class LoggerService
{
    public static void LogDay(int day)
    {
        Console.WriteLine($"-------- day {day} --------");
    }

    public static void LogItems(List<Item> items)
    {
        Console.WriteLine("name, sellIn, quality");
        for (var j = 0; j < items.Count; j++)
        {
            Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
        }
        Console.WriteLine("");
    }

    public static void LogStart()
    {
        Console.WriteLine("OMGHAI!");
    }
}