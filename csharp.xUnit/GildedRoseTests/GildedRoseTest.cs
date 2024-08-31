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
    //private void UpdateConjuredItem(Item item)
    //{
    //    item.Quality -= item.SellIn > 0 ? 2 : 4;
    //}
    [Fact]
    private void UpdateConjuredItemWithQualityGreaterThanZero()
    {
        //arrange
        List<Item> Items = [new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 2 }];
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Items[0].Quality.Should().Be(0);
    }
    [Fact]
    private void UpdateConjuredItemWithQualityEqualsZero()
    {
        //arrange
        List<Item> Items = [new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 4 }];
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Items[0].Quality.Should().Be(0);
    }

    [Fact]
    private void EnsureConjuredItemDecrements()
    {
        //arrange
        List<Item> Items = [new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 4 }];
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Items[0].SellIn.Should().Be(-1);
    }
}