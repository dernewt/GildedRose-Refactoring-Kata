namespace GildedRoseTests.ItemTests;

public class BackstagePassTest
{
    [Fact]
    public void SellInDecresesByOne()
    {
        var startsAtOne = new Item { SellIn = 1 };

        new BackstagePass(startsAtOne)
            .Update();

        startsAtOne.SellIn.Should()
            .Be(0, "...lowers both values for every item");
    }

    [Fact]
    public void QualityIncreasesByOne()
    {
        var startsAtTen = new Item { SellIn = 11, Quality = 10 };

        new BackstagePass(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(11, "Backstage passes ... increases in Quality");
    }

    [Fact]
    public void QualityIncreasesFasterUnderTen()
    {
        var startsAtTen = new Item { SellIn = 10, Quality = 10 };

        new BackstagePass(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(12, "Quality increases by 2 when there are 10 days or less");
    }

    [Fact]
    public void QualityIncreasesFasterUnderFive()
    {
        var startsAtTen = new Item { SellIn = 5, Quality = 10 };

        new BackstagePass(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(13, "and by 3 when there are 5 days");
    }

    [Fact]
    public void QualityDropsWhenExpired()
    {
        var startsAtTen = new Item { SellIn = 0, Quality = 10 };

        new BackstagePass(startsAtTen)
            .Update();

        startsAtTen.Quality.Should()
            .Be(0, "Quality drops to 0 after the concert");
    }

    [Fact]
    public void QualityStopsAtFifty()
    {
        var startsAtFifty = new Item { Quality = 50, SellIn = 1 };

        new BackstagePass(startsAtFifty)
            .Update();

        startsAtFifty.Quality.Should()
            .Be(50, "The Quality of an item is never more than 50");
    }
}