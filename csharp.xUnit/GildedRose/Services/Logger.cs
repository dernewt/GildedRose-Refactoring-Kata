namespace GildedRoseKata.Services;

public static class Logger
{
    public static void LogStart()
    {
        Console.WriteLine("OMGHAI!");
    }
    public static void LogDay(int day)
    {
        Console.WriteLine($"-------- day {day} --------");
    }

    public static void LogItems(IEnumerable<Item> items)
    {
        Console.WriteLine("name, sellIn, quality");
        foreach (Item item in items)
        {
            Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
        }
        Console.WriteLine();
    }
}
