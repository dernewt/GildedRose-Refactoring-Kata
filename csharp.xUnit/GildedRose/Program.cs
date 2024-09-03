using GildedRoseKata;
using GildedRoseKata.Services;

LoggerService.LogStart();

var items = ItemService.Fetch();

var app = new GildedRose(items);

var days = ProgramHelper.ParseArgs(args);

for (var i = 0; i <= days; i++)
{
    LoggerService.LogDay(i);
    LoggerService.LogItems(items);
    app.UpdateQuality();
}
