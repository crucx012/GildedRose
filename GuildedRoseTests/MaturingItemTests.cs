using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class MaturingItemTests
    {
        private List<Item> _items;
        private UpdateStrategy _updateStrategy;

        [TestInitialize]
        public void Initialize()
        {
            _items = new List<Item>
                {
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 49},
                    new Item {Name = "Aged Brie", SellIn = -1, Quality = 50},
                    new Item {Name = "Aged Brie", SellIn = 0, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 0, Quality = 50},
                };
            _updateStrategy = new UpdateStrategy(_items);
        }

        [TestMethod]
        public void IncreaseQualityBy1()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(50, _items[0].Quality);
        }

        [TestMethod]
        public void IncreaseQualityOnlyToMax50()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(50, _items[1].Quality);
        }

        [TestMethod]
        public void IncreaseQualityBy2AfterSellInIsBelow0()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(22, _items[2].Quality);
        }

        [TestMethod]
        public void IncreaseQualityOnlyToMax50AfterSellInIsBelow0()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(50, _items[3].Quality);
        }
    }
}
