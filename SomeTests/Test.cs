using System;
using NUnit.Framework;
using GildedRose.Console;
using System.Collections.Generic;


namespace SomeTests
{
  [TestFixture()]
  public class Test
  {
    ItemAger _itemAger;

    [SetUp()]
    public void SetUp()
    {
      _itemAger = new ItemAger();
    }

    [Test()]
    public void CanRunItemAger()
    {
      _itemAger.Items = new List<Item>();
      _itemAger.UpdateQuality();
      Assert.DoesNotThrow(() => _itemAger.UpdateQuality());
    }

    [Test]
    public void StandardItemQualityDecrementsAfterUpdate()
    {
      var items = new List<Item>{ new Item(){Name="std",SellIn=99,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(19));
    }

    [Test]
    public void StandardItemSellInDecrementsAfterUpdate()
    {
      var items = new List<Item>{ new Item(){Name="std",SellIn=99,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].SellIn,Is.EqualTo(98));
    }

  }
}

