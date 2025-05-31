using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayManagerTests
{
    private GameObject obj;
    private TextDisplayManager manager;
    private Text uiText;

    [SetUp]
    public void Setup()
    {
        obj = new GameObject();
        manager = obj.AddComponent<TextDisplayManager>();
        var canvasObj = new GameObject();
        canvasObj.transform.SetParent(obj.transform);
        uiText = canvasObj.AddComponent<Text>();
        manager.GetType().GetField("uiText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(manager, uiText);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(obj);
    }

    [Test]
    public void ShowUniqueText_DisplaysOnce()
    {
        manager.ShowUniqueText("test1", "Hello World");
        Assert.IsTrue(manager.GetType().GetField("displayedTexts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(manager) is HashSet<string> set && set.Contains("test1"));

        manager.ShowUniqueText("test1", "Hello Again"); // має проігнорувати
        Assert.AreEqual("Hello World", uiText.text);
    }
}