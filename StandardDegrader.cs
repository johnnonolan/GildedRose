using System.Collections.Generic;
using System;

    namespace GildedRose.Console
    {

    public class StandardDegrader:  IDegradable
    {
        public void AugmentQuality(Item item)
        {
            if(item.Quality >=0)
            {
                item.Quality--;
                if(item.SellIn < 0)
                    item.Quality--;
            }
        }

        public void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }

}
