using System.Collections.Generic;
using System;

    namespace GildedRose.Console
    {
        public class Program
        {          
            public static void Main(string[] args)
            {
                System.Console.WriteLine("Hello World!");

                var app = new ItemAger()
                {
                  Items = new List<Item>
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
                  }
                  
                };
                
                app.UpdateQuality();
                
                System.Console.ReadKey();
              }
        }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public class DegraderFactory
    {
        public static IDegradable GetDegrader(Item item)
        {
            switch (item.Name) 
            {
                case "Sulfuras, Hand of Ragnaros": return new SulfurasDegrader();
                case "Aged Brie": return new BrieDegrader();
                case "Backstage passes to a TAFKAL80ETC concert": return new BackStageDegrader();
                case "Conjured Mana Cake": return new ConjouredDegrader();
                default: return new StandardDegrader();
            }
        }
    }

  public class ItemAger 
  {
    public IList<Item> Items;

    void AugmentQuality(Item item)
    {
        IDegradable degrader = DegraderFactory.GetDegrader(item);
        degrader.AugmentQuality(item);
    }

    void DecrementSellIn(Item item)
    {
        IDegradable degrader = DegraderFactory.GetDegrader(item);
        degrader.DecreaseSellIn(item);
    }
    
    public void UpdateQuality()
    {
        foreach (var item in Items) 
        {
            DecrementSellIn(item);
            AugmentQuality(item);
        }
    }

  }

}
