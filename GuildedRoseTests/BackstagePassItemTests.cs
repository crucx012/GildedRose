using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class BackstagePassItemTests
    {
        private List<Item> _items;
        private UpdateStrategy _updateStrategy;

        [TestInitialize]
        public void Initialize()
        {
            _items = new List<Item>
                {
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 48},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 48},
                };
            _updateStrategy = new UpdateStrategy(_items);
        }

        [TestMethod]
        public void IncreaseQualityBy2()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(12, _items[0].Quality);
        }

        [TestMethod]
        public void IncreaseQualityBy3()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(13, _items[1].Quality);
        }

        [TestMethod]
        public void SellIn0AfterUpdate_IncreaseQualityToMax50()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(50, _items[2].Quality);
        }
        
        [TestMethod]
        public void ReduceQualityTo0AfterSellInIsNegative()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(0, _items[3].Quality);
        }
    }
}
