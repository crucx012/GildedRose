using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        static IList<Item> _items;
        static UpdateStrategy _updateStrategy;

        public Program(IList<Item> items)
        {
            _items = items;
            _updateStrategy = new UpdateStrategy(_items);
        }

        private static void Main()
        {
            System.Console.WriteLine("OMGHAI!");
            Initialize();

            _items = _updateStrategy.Update();

            System.Console.ReadKey();
        }

        private static void Initialize()
        {
            _items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                };
        }
    }
}