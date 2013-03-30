using System.Collections.Generic;
using System;

namespace GildedRose.Console
{
	public class ConjouredDegrader : IDegradable
	{

        public void AugmentQuality(Item item)
        {
            item.Quality = item.Quality -2;
            if (item.Quality < 0) item.Quality =0;
        }
        public void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

	}


    

    

  

}
