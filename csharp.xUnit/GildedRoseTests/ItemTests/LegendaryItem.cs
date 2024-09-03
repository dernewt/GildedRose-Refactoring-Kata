namespace GildedRoseTests.ItemTests;

public class LegendaryItemTest
{
    [Fact]
    public void SellInDoesNotChange()
    {
        var startsAtOne = new Item { SellIn = 1 };

        new LegendaryItem(startsAtOne)
            .Update();

        startsAtOne.SellIn.Should()
            .Be(1, "Sulfuras, being a legendary item, never has to be sold");
    }

    [Fact]
    public void QualityDoesNotChange()
    {
        var startsAtTen = new Item { SellIn = 1, Quality = 10 };

        new LegendaryItem(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(10, "Sulfuras, being a legendary item, never ... decreases in Quality");
    }

}