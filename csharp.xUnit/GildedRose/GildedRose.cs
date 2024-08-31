using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public string[] specialItems = { "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros", "Conjured" };

    public bool IsSpecialItem(string itemName)
    {
        return specialItems.Contains(itemName);
    }
    private void UpdateConjuredItem(Item item)
    {
        item.Quality -= item.SellIn > 0 ? 2 : 4;
        item.SellIn -= 1;
        if (item.Quality <= 0)
        {
            item.Quality = 0;
        }
    }
    public void IncreaseQuantity(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }

        }
    }


    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name.StartsWith("Conjured"))
            {
                UpdateConjuredItem(Items[i]);
                continue;
            }
            
                if (Items[i].Quality > 0 && !IsSpecialItem(Items[i].Name) )
                {
                Items[i].Quality = Items[i].Quality - 1;
                }
                else
                {
                    IncreaseQuantity(Items[i]);
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name == "Aged Brie" && Items[i].Quality < 50) {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                   else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert") {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }

                    else if (Items[i].Quality > 0 && !IsSpecialItem(Items[i].Name))
                    {   
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
        }
    }

  
}