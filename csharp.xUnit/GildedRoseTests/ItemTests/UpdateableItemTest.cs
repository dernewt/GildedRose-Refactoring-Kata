namespace GildedRoseTests.ItemTests;

public class UpdateableItemTest
{
    [Theory]
    [InlineData("", typeof(RegularItem))]
    [InlineData("+1 sword of swinging", typeof(RegularItem))]
    [InlineData("Conjured dagger", typeof(ConjuredItem))]
    [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItem))]
    [InlineData("Backstage passes to concert", typeof(BackstagePass))]
    [InlineData("Aged Brie", typeof(AgedBrie))]
    public void ParsesItemType(string name, Type resultsIn)
    {
        var item = new Item { Name = name };
        var itemType = item.AsUpdatableItem();
        itemType.Should().BeOfType(resultsIn, $"because name was {name}");
    }
}
