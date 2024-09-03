using GildedRoseKata.Services;
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

    private void UpdateConjuredItem(Item item)
    {
        item.Quality -= item.SellIn > 0 ? 2 : 4;
        item.SellIn -= 1;
        if (item.Quality <= 0)
        {
            item.Quality = 0;
        }
    }
    private void IncreaseQualityBackStagePass(Item item)
    {
        if (item.SellIn < 11 && item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }
        if (item.SellIn < 6 && item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

    }
    public void IncreaseQuantity(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseQualityBackStagePass(item);
            }

        }
    }

    public void updateIndividualItemQuality(Item item)
    {
        if (item.Quality > 0 && !ItemService.IsSpecialItem(item.Name))
        {
            item.Quality -= 1;
        }
        else
        {
            IncreaseQuantity(item);
        }

        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn = item.SellIn - 1;
        }
        //To Do: think about refactoried aged brie into increased quanity
        if (item.SellIn < 0)
        {
            if (item.Name == "Aged Brie" && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = item.Quality - item.Quality;
            }

            else if (item.Quality > 0 && !ItemService.IsSpecialItem(item.Name))
            {
                item.Quality = item.Quality - 1;
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
            updateIndividualItemQuality(Items[i]);
        }
    }
}