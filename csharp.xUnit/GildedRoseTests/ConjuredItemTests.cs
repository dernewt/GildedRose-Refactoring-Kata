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

namespace GildedRoseTests
{
    public class ConjuredItemTests
    {
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
}
