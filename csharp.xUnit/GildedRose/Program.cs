using GildedRoseKata;
using GildedRoseKata.Services;

Logger.LogStart();

var items = ItemService.Fetch();

int daysToRun = Configuration.ParseDays(args) ?? 2;

Logger.LogDay(0);
Logger.LogItems(items);

var app = new GildedRose(items);
foreach (var day in Enumerable.Range(1, daysToRun))
{
    app.UpdateQuality();

    Logger.LogDay(day);
    Logger.LogItems(items);
}
