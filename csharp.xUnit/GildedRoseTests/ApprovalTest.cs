using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using GildedRoseKata;
using System.Collections.Generic;
using FluentAssertions;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));

        Assembly.GetAssembly(typeof(GildedRose))
            .EntryPoint.Invoke(this, new[] { new[] { "30" } });

        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
    //TODO: make conjured item unit test and move logic to separete file for conjured item file / services
    [Fact]
    public void EnsureConjuredItemsQualityDoesNotGoNegative()
    {
        //arrange
        List<Item> Items = [new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 }];
        //act
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        //assert
        Items[0].Quality.Should().Be(0);
    }
    [Fact]
    public void IsSpecialItem_ShouldReturnFalseForNonSpecialItems()
    {
        // Arrange
        var gildedRose = new GildedRose(new List<Item>());

        // Act & Assert
        Assert.False(gildedRose.IsSpecialItem("Normal Item"));
        Assert.False(gildedRose.IsSpecialItem("Conjured Mana Cake"));
    }
    [Fact]
    public void IsSpecialItem_ShouldReturnTrueForSpecialItems()
    {
        var gildedRose = new GildedRose(new List<Item>());
        // Act & Assert
        Assert.True(gildedRose.IsSpecialItem("Aged Brie"));
        Assert.True(gildedRose.IsSpecialItem("Backstage passes to a TAFKAL80ETC concert"));
        Assert.True(gildedRose.IsSpecialItem("Sulfuras, Hand of Ragnaros"));

    }
}