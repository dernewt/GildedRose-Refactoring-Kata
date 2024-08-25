using System.Linq;

namespace GildedRoseKata;

class ProgramHelper
{
    public static int ParseArgs(string[] args)
    {
        if (int.TryParse(args.FirstOrDefault(), out var days))
            return days;

        return 1;
    }
}
