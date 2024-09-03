namespace GildedRoseTests.ItemTests;

public class RegularItemTest
{
    [Fact]
    public void SellInDecresesByOne()
    {
        var startsAtOne = new Item { SellIn = 1 };

        new RegularItem(startsAtOne)
            .Update();

        startsAtOne.SellIn.Should()
            .Be(0, "...lowers both values for every item");
    }

    [Fact]
    public void QualityDecresesByOne()
    {
        var startsAtTen = new Item { SellIn = 1, Quality = 10 };

        new RegularItem(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(9, "...lowers both values for every item");
    }
    [Fact]
    public void ExpiredQualityDecresesByTwo()
    {
        var expiredStartsAtTen = new Item { SellIn = 0, Quality = 10 };

        new RegularItem(expiredStartsAtTen)
            .Update();

        expiredStartsAtTen.Quality.Should()
            .Be(8, "Once the sell by date has passed, Quality degrades twice as fast");
    }

    [Fact]
    public void QualityStopsAtZero()
    {
        var startsAtZero = new Item { Quality = 0 };

        new RegularItem(startsAtZero)
            .Update();

        startsAtZero.Quality.Should()
            .Be(0, "The Quality of an item is never negative");
    }
}