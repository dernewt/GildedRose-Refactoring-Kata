﻿namespace GildedRoseKata.Services;

public static class ItemService
{
    public static List<Item> Fetch() => new()
    {
        new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
        new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
        new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
        new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
        new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
        new() {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 15,
            Quality = 20
        },
        new() {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 10,
            Quality = 49
        },
        new() {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 5,
            Quality = 49
        },

        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
    };
}
