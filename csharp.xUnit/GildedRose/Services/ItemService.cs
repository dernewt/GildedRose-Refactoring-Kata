using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.Services;

public class ItemService
{
    public static List<Item> Fetch() =>
    [
        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
        new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 15,
            Quality = 20
        },
        new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 10,
            Quality = 49
        },
        new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 5,
            Quality = 49
        },
        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
    ];
    public static bool IsSpecialItem(string itemName)
    {
        string[] specialItems = { "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros", "Conjured Mana Cake" };
        return specialItems.Contains(itemName);
    }
}
