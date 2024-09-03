namespace GildedRoseKata.Items;

public class BackstagePass(Item source) : UpdatableItem(source)
{
    protected override void UpdateItemQuality()
    {
        Source.Quality += Source.SellIn switch {
            > 10 => 1,
            > 5 => 2,
            > 0 => 3,
            <= 0 => -Source.Quality, //zero out
        };
    }
}
