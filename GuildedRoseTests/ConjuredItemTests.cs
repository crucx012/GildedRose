using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class ConjuredItemTests
    {
        private List<Item> _items;
        private UpdateStrategy _updateStrategy;

        [TestInitialize]
        public void Initialize()
        {
            _items = new List<Item>
                {
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                    new Item {Name = "Conjured Mana Cake", SellIn = -1, Quality = 6},                    
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 1}                    
                };
            _updateStrategy = new UpdateStrategy(_items);
        }

        [TestMethod]
        public void ReduceQualityBy2()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(4, _items[0].Quality);
        }

        [TestMethod]
        public void ReduceQualityBy4AfterSellInIsBelow0()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(2, _items[1].Quality);
        }

        [TestMethod]
        public void ReduceSellInBy1()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(2, _items[2].SellIn);
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
