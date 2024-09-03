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

    private void UpdateQualityNonSpecialItem(Item item)
    {

        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
        item.SellIn = item.SellIn - 1;
        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality = item.Quality - 1;
        }
    }
    private void UpdateQualitySpecialItem(Item item)
    {
        if (item.Quality < 50 && !item.Name.StartsWith("Conjured"))
        {
            item.Quality = item.Quality + 1;

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                IncreaseQualityBackStagePass(item);
            }
            if (item.Name == "Aged Brie" && item.SellIn <= 0)
            {
                item.Quality = item.Quality + 1;
            }
            if (item.SellIn < 0)
            {
                if (item.Quality > 0 && !ItemService.IsSpecialItem(item.Name))
                {
                    item.Quality = item.Quality - 1;
                }
            }

        }
        else if (item.Name.StartsWith("Conjured"))
        {
            UpdateConjuredItem(item);
        }
        if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn <= 0)
        {
            item.Quality = item.Quality - item.Quality;
        }

        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn = item.SellIn - 1;
        }

    }



    private void UpdateQualityIndividualItem(Item item)
    {
        if (!ItemService.IsSpecialItem(item.Name))
        {
            UpdateQualityNonSpecialItem(item);
        }
        else
        {
            UpdateQualitySpecialItem(item);
        }

    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateQualityIndividualItem(Items[i]);
        }
    }
}