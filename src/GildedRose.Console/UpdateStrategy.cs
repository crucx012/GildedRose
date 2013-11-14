using System.Collections.Generic;

namespace GildedRose.Console
{
    public class UpdateStrategy
    {
        static IList<Item> _items;
        static Item _item;

        public UpdateStrategy(IList<Item> items)
        {
            _items = items;
        }

        public IList<Item> Update()
        {
            foreach (Item i in _items)
            {
                _item = i;
                UpdateQuality();
                ReduceSellIn();
                PostUpdate();
            }
            return _items;
        }

        public static int Quality
        {
            get { return _item.Quality; }
            set { _item.Quality = value; }
        }

        public static int SellIn
        {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        private static void UpdateQuality()
        {
            if (IsItemAgedBrie())
                IncreaseQuality();
            else if (IsItemBackstagePasses())
                IncreaseQualityOfPasses();
            else if (IsItemConjured())
                DecreaseConjuredItemQuality();
            else if (!IsItemSulfuras())
                DecreaseQuality();
        }

        private static void IncreaseQualityOfPasses()
        {
            IncreaseQuality();
            if (SellIn <= 10)
                IncreaseQuality();
            if (SellIn <= 5)
                IncreaseQuality();
        }

        private static void IncreaseQuality()
        {
            if (Quality < 50)
                Quality++;
        }

        private static void DecreaseConjuredItemQuality()
        {
            DecreaseQuality();
            DecreaseQuality();
        }

        private static void DecreaseQuality()
        {
            if (Quality > 0)
                Quality--;
        }

        private static void ReduceSellIn()
        {
            if (!IsItemSulfuras())
                SellIn--;
        }

        private static void PostUpdate()
        {
            if (SellIn >= 0) return;
            if (IsItemAgedBrie())
                UpdateQuality();
            else if (IsItemBackstagePasses())
                _item.Quality = 0;
            else if (IsItemConjured())
                UpdateQuality();
            else if (Quality > 0)
                DecreaseQuality();
        }

        private static bool IsItemAgedBrie()
        {
            return _item.Name == "Aged Brie";
        }

        private static bool IsItemBackstagePasses()
        {
            return _item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsItemConjured()
        {
            return _item.Name == "Conjured Mana Cake";
        }

        private static bool IsItemSulfuras()
        {
            return _item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}