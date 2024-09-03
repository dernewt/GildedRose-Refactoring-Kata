namespace GildedRoseTests.ItemTests;

public class ConjuredItemTest
{
    [Fact]
    public void SellInDecresesByOne()
    {
        var startsAtOne = new Item { SellIn = 1 };

        new ConjuredItem(startsAtOne)
            .Update();

        startsAtOne.SellIn.Should()
            .Be(0, "...lowers both values for every item");
    }

    [Fact]
    public void QualityDecreasesByTwo()
    {
        var startsAtTen = new Item { SellIn = 1, Quality = 10 };

        new ConjuredItem(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(8, "Conjured items degrade in Quality twice as fast as normal items");
    }
    [Fact]
    public void ExpiredQualityDecresesByFour()
    {
        var expiredStartsAtTen = new Item { SellIn = 0, Quality = 10 };

        new ConjuredItem(expiredStartsAtTen)
            .Update();

        expiredStartsAtTen.Quality.Should()
            .Be(6, "Conjured items degrade in Quality twice as fast as normal items");
    }

    [Fact]
    public void QualityStopsAtZero()
    {
        var startsAtZero = new Item { Quality = 0 };

        new ConjuredItem(startsAtZero)
            .Update();

        startsAtZero.Quality.Should()
            .Be(0, "The Quality of an item is never negative");
    }
}