using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRoseTests
{
    [TestClass]
    public class LegendaryItemTests
    {
        private List<Item> _items;
        private UpdateStrategy _updateStrategy;

        [TestInitialize]
        public void Initialize()
        {
            _items = new List<Item>
                {
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                };
            _updateStrategy = new UpdateStrategy(_items);
        }

        [TestMethod]
        public void DoesNotReduceQuality()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(80, _items[0].Quality);
        }

        [TestMethod]
        public void DoesNotReduceSellBy()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(0, _items[0].SellIn);
        }

        [TestMethod]
        public void SellInNegative_UpdateDoesNotDecreaseQuality()
        {
            Initialize();
            _updateStrategy.Update();
            Assert.AreEqual(80, _items[0].Quality);
        }
    }
}
