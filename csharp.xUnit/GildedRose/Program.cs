using GildedRoseKata;
using GildedRoseKata.Services;

Logger.LogStart();

var items = ItemService.Fetch();

var app = new GildedRose(items);

var days = ProgramHelper.ParseArgs(args);

for (var i = 0; i <= days; i++)
{
    Logger.LogDay(i);
    Logger.LogItems(items);
    app.UpdateQuality();
}
