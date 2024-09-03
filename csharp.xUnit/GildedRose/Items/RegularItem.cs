namespace GildedRoseKata.Items;

public class RegularItem(Item source) : UpdatableItem(source)
{
    protected override void UpdateItemQuality()
    {
        Source.Quality += Source.SellIn > 0 ? -1 : -2;
    }
}
