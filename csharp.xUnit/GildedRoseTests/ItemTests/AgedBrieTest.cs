namespace GildedRoseTests.ItemTests;

public class AgedBrieTest
{
    [Fact]
    public void SellInDecreasesByOne()
    {
        var startsAtZero = new Item { SellIn = 0 };

        new AgedBrie(startsAtZero)
            .Update();

        startsAtZero.SellIn.Should()
            .Be(-1, "...lowers both values for every item");
    }

    [Fact]
    public void QualityIncreasesByOne()
    {
        var startsAtTen = new Item { SellIn = 1, Quality = 10 };

        new AgedBrie(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(11, "Aged Brie actually increases in Quality");
    }
    [Fact]
    public void ExpiredQualityIncreasesByTwo()
    {
        var expiredStartsAtTen = new Item { SellIn = 0, Quality = 10 };

        new AgedBrie(expiredStartsAtTen)
            .Update();

        expiredStartsAtTen.Quality.Should()
            .Be(12, "Aged Brie actually increases in Quality the older it gets");
    }

    [Fact]
    public void QualityStopsAtFifty()
    {
        var startsAtFifty = new Item { Quality = 50 };

        new AgedBrie(startsAtFifty)
            .Update();

        startsAtFifty.Quality.Should()
            .Be(50, "The Quality of an item is never more than 50");
    }
}