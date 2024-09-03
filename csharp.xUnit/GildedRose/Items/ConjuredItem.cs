namespace GildedRoseKata.Items;

public class ConjuredItem(Item source) : UpdatableItem(source)
{
    protected override void UpdateItemQuality()
    {
        Source.Quality += Source.SellIn > 0 ? -2 : -4;
    }
}
