using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class BasicItemTests
    {
        private List<Item> _items;
        private UpdateStrategy _updateStrategy;

        [TestInitialize]
        public void Initialize()
        {
            _items = new List<Item>
                {
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Elixir of the Mongoose", SellIn = -1, Quality = 6},
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0},
                };
            _updateStrategy = new UpdateStrategy(_items);
        }

        [TestMethod]
        public void ReduceQualityBy1()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(6, _items[0].Quality);
        }

        [TestMethod]
        public void ReduceQualityBy2AfterSellInIsBelow0()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(4, _items[1].Quality);
        }

        [TestMethod]
        public void ReduceSellInBy1()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(9, _items[2].SellIn);
        }

        [TestMethod]
        public void ReduceQualityOnlyToMin0()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(0, _items[3].Quality);
        }
    }
}
