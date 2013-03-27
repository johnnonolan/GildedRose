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

    [Test]
    public void StandardItemPastSellInQualityDoubleDecrementsAfterUpdate()
    {
      var items = new List<Item>{ new Item(){Name="std",SellIn=-1,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(18));
    }

    [Test]
    public void BackstagePassesQualityIncreasesBy2WhereSellInLessThan10()
    {
      var items = new List<Item>{ new Item(){Name="Backstage passes to a TAFKAL80ETC concert",SellIn=9,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(22));
    }


    [Test]
    public void BackstagePassesQualityIncreasesBy3WhereSellInLessThan6()
    {
      var items = new List<Item>{ new Item(){Name="Backstage passes to a TAFKAL80ETC concert",SellIn=5,Quality=20},
        new Item(){Name="Backstage passes to a TAFKAL80ETC concert",SellIn=6,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(23));
      Assert.That(items[1].Quality,Is.EqualTo(22));
    }

    [Test]

    public void BackstagePassesQualityZerosWhereSellInBecomesLessThan0()
    {
      var items = new List<Item>{ new Item(){Name="Backstage passes to a TAFKAL80ETC concert",SellIn=0,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(0));
    }

    [Test]
    public void AgedBrieQualityIncreasesBy1IfSellinGreaterThan10()
    {
      var items = new List<Item>{ new Item(){Name="Aged Brie",SellIn=11,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(21));

    }

    [Test]
    public void AgedBrieQualityIncreasesIfSellinNotLessThan0()
    {
      var items = new List<Item>{ new Item(){Name="Aged Brie",SellIn=5,Quality=20}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(21));

    }

    [Test]
    public void SulfurasQualityNeverChanges()
    {
      var items = new List<Item>{ new Item(){Name="Sulfuras, Hand of Ragnaros",SellIn=5,Quality=80}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(80));
    }

    [Test]

    public void QualityNeverIncreasesBeyond50()
    {
      var items = new List<Item>{ new Item(){Name="Aged Brie",SellIn=5,Quality=50}};
      _itemAger.Items = items;
      _itemAger.UpdateQuality();
      Assert.That(items[0].Quality,Is.EqualTo(50));
    }
  }
}

