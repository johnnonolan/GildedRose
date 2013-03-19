using System;
using NUnit.Framework;
using GildedRose.Console;
using System.Collections.Generic;


namespace SomeTests
{
  [TestFixture()]
  public class Test
  {
    [Test()]
    public void CanRunProject()
    {
      var itemAger = new ItemAger{ Items = new List<Item>() };
        itemAger.UpdateQuality();
    }


  }
}

