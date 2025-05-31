using NUnit.Framework;
using UnityEngine;

public class SceneManager3DTests
{
    private GameObject sceneManagerObj;
    private SceneManager3D sceneManager;

    [SetUp]
    public void Setup()
    {
        sceneManagerObj = new GameObject();
        sceneManager = sceneManagerObj.AddComponent<SceneManager3D>();
        SceneManager3D.Instance = sceneManager;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(sceneManagerObj);
    }

    [Test]
    public void AdvancePhase_ChangesPhaseAndRecordsAction()
    {
        bool changed = sceneManager.AdvancePhase(GamePhase.Sleep);
        Assert.IsTrue(changed);
        Assert.AreEqual(GamePhase.Sleep, sceneManager.CurrentPhase);

        // Повторне додавання фази має повернути false
        changed = sceneManager.AdvancePhase(GamePhase.Sleep);
        Assert.IsFalse(changed);
    }

    [Test]
    public void IsDoorUnlocked_ReturnsCorrectValues()
    {
        sceneManager.CurrentPhase = GamePhase.SearchingNoteBathroom;
        Assert.IsTrue(sceneManager.IsDoorUnlocked("BD"));
        Assert.IsFalse(sceneManager.IsDoorUnlocked("Fridge"));
    }
}