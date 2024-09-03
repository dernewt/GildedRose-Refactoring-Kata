namespace GildedRoseKata.Items;

public abstract class UpdatableItem(Item source)
{
    protected Item Source = source;

    public void Update()
    {
        UpdateItemQuality();

        EnforceQualityLimit();

        UpdateSellIn();
    }

    protected abstract void UpdateItemQuality();

    protected virtual void UpdateSellIn()
    {
        --Source.SellIn;
    }

    protected int MaxQuality = 50;
    protected int MinQuality = 0;
    protected virtual void EnforceQualityLimit()
    {
        if(Source.Quality >  MaxQuality)
        {
            Source.Quality = MaxQuality;
        }
        else if (Source.Quality < MinQuality)
        {
            Source.Quality = MinQuality;
        }
    }
}

public static class BetterItemHelper
{
    public static UpdatableItem AsUpdatableItem(this Item source) => source.Name switch
    {
        "Sulfuras, Hand of Ragnaros" => new LegendaryItem(source),
        "Aged Brie" => new AgedBrie(source),
        string n when n.StartsWith("Conjured ") => new ConjuredItem(source),
        string n when n.StartsWith("Backstage passes to ") => new BackstagePass(source),
        _ => new RegularItem(source),
    };
}
