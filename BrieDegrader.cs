using System.Collections.Generic;
using System;

namespace GildedRose.Console
{
	public class BrieDegrader : IDegradable
	{
        public void AugmentQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality++;
        }

        public void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
	}

    public class BackStageDegrader : IDegradable
    {
        public void AugmentQuality(Item item)
        {
            if (item.Quality < 50)
            {
                if (item.SellIn < 5)
                {
                    item.Quality +=3;
                }
                else if (item.SellIn <10)
                {
                    item.Quality +=2;
                } else
                {
                    item.Quality ++;
                }
                if (item.Quality > 50)
                    item.Quality = 50;
            }
        }
        
        public void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
