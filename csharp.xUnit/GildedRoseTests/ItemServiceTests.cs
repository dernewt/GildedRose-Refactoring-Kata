using GildedRoseKata.Services;
using GildedRoseKata;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace GildedRoseTests
{
    public class ItemServiceTests
    {
        [Fact]
        public void IsSpecialItem_ShouldReturnFalseForNonSpecialItems()
        {
            Assert.False(ItemService.IsSpecialItem("Normal Item"));
            Assert.False(ItemService.IsSpecialItem("Conjured Mana Cake"));
        }
        [Fact]
        public void IsSpecialItem_ShouldReturnTrueForSpecialItems()
        {
            Assert.True(ItemService.IsSpecialItem("Aged Brie"));
            Assert.True(ItemService.IsSpecialItem("Backstage passes to a TAFKAL80ETC concert"));
            Assert.True(ItemService.IsSpecialItem("Sulfuras, Hand of Ragnaros"));
        }
    }
}
