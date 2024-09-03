using GildedRoseKata.Items;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly IList<Item> _items = items;
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.AsUpdatableItem().Update();
        }
    }
    
}