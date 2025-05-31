using NUnit.Framework;
using UnityEngine;

public class PickUpItemTests
{
    private GameObject playerObj;
    private PickUpItem pickUp;

    [SetUp]
    public void Setup()
    {
        playerObj = new GameObject();
        pickUp = playerObj.AddComponent<PickUpItem>();

        // Створимо "предмет" для підбору
        var item = GameObject.CreatePrimitive(PrimitiveType.Cube);
        item.tag = "Item";
        item.AddComponent<Rigidbody>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(playerObj);
        foreach (var go in Object.FindObjectsOfType<GameObject>())
            Object.DestroyImmediate(go);
    }

    [Test]
    public void PickUp_SetsCurrentItemAndFlags()
    {
        var item = GameObject.FindWithTag("Item");
        pickUp.currentItem = null;

        // Симулюємо підбір
        pickUp.currentItem = item;
        PickUpItem.isHoldingKey = false;

        Assert.AreEqual(item, pickUp.currentItem);
        Assert.IsFalse(PickUpItem.isHoldingKey);

        // Симулюємо підбір ключа
        item.name = "GoldenKey";
        pickUp.currentItem = item;
        PickUpItem.isHoldingKey = item.name.ToLower().Contains("key");

        Assert.IsTrue(PickUpItem.isHoldingKey);
    }

    [Test]
    public void DestroyHeldKey_RemovesCurrentItem()
    {
        var item = GameObject.FindWithTag("Item");
        item.name = "KeyItem";
        pickUp.currentItem = item;
        PickUpItem.isHoldingKey = true;

        pickUp.DestroyHeldKey();

        Assert.IsNull(pickUp.currentItem);
        Assert.IsFalse(PickUpItem.isHoldingKey);
    }
}