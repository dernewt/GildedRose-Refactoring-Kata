namespace GildedRoseKata.Services;

public static class Configuration
{
    public static int? ParseDays(string[] args)
    {
        if (int.TryParse(args.FirstOrDefault(), out int days))
            return days;

        return null;
    }
}
