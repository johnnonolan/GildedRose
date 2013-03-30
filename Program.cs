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


    public class SulfurasDegrader:  IDegradable
    {
      public void AugmentQuality(Item item)
      {

      }

      public void DecreaseSellIn(Item item )
      {

      }
    }

    public class StandardDegrader:  IDegradable
    {
        public void AugmentQuality(Item item)
        {
            if(item.Quality >0)
                item.Quality--;
        }

        public void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }

    public class DegraderFactory
    {
        public static IDegradable GetDegrader(Item item)
        {
            switch (item.Name) {
                case "Sulfuras, Hand of Ragnaros": return new SulfurasDegrader();
                case "Aged Brie": return new BrieDegrader();
                case "Backstage passes to a TAFKAL80ETC concert": return new BackStageDegrader();
                default: return new StandardDegrader();
            }
        }
    }

  public class ItemAger 
  {
    public IList<Item> Items;

    void AugmentQuality(int index)
    {
        IDegradable degrader = DegraderFactory.GetDegrader(Items[index]);
        degrader.AugmentQuality(Items[index]);

        if (Items[index].SellIn < 0)
        {
            if (Items[index].Name != "Aged Brie")
            {
                if (Items[index].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[index].Quality > 0)
                    {
                        Items[index].Quality = Items[index].Quality - 1;
                    }
                }
                else
                {
                    Items[index].Quality = Items[index].Quality - Items[index].Quality;
                }
            }
            else
            {
                if (Items[index].Quality < 50)
                {
                    Items[index].Quality = Items[index].Quality + 1;
                }
            }
        }
    }

    void DecrementSellIn(Item item)
    {
        IDegradable degrader = new SulfurasDegrader();
        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
          //degrader.AugmentQuality();
          degrader.DecreaseSellIn(item);
          return;
        }

        item.SellIn = item.SellIn - 1;

    }
    
    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            DecrementSellIn(Items[i]);
            AugmentQuality(i);
        }
    }

  }

}
