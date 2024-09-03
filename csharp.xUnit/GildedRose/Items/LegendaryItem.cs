namespace GildedRoseKata.Items;

public class LegendaryItem : UpdatableItem
{
    public LegendaryItem(Item source) : base(source)
    {
        MinQuality = int.MinValue;
        MaxQuality = int.MaxValue;
    }

    protected override void UpdateSellIn()
    {
        //sell in never changes
    }

    protected override void UpdateItemQuality()
    {
        //quality never changes
    }

}
