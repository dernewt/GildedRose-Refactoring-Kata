using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void GenericItemWithZerosUpdated()
    {
        List<Item> Items = [new Item { Name = "foo", SellIn = 0, Quality = 0 }];
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Items[0].Name.Should().Be("foo");
        Items[0].Quality.Should().Be(0);
        Items[0].SellIn.Should().Be(-1);
    }

    [Fact]
    public void GenericItemWithOneUpdated()
    {
        List<Item> Items = [new Item { Name = "foo", SellIn = 1, Quality = 1 }];
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Items[0].Name.Should().Be("foo");
        Items[0].Quality.Should().Be(0);
        Items[0].SellIn.Should().Be(0);
    }
}