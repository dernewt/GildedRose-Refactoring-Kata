namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void MultiValueTest()
    {
        var startingValue = 42;
        IList<Item> items =
            [
            new() { SellIn = startingValue, Quality = startingValue },
            new() { SellIn = startingValue, Quality = startingValue }
            ];

        new GildedRose(items)
            .UpdateQuality();

        items.First().Quality.Should().NotBe(startingValue);
        items.First().SellIn.Should().NotBe(startingValue);
        items.Last().Quality.Should().NotBe(startingValue);
        items.Last().SellIn.Should().NotBe(startingValue);
    }

    [Fact]
    public void EmptyTest()
    {
        GildedRose app = new GildedRose(new List<Item>());

        app.UpdateQuality();

        app.Should().NotBeNull();
    }
}