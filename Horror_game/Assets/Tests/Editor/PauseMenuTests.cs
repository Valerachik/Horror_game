using NUnit.Framework;
using UnityEngine;

public class PauseMenuTests
{
    private GameObject obj;
    private PauseMenu pauseMenu;

    [SetUp]
    public void Setup()
    {
        obj = new GameObject();
        pauseMenu = obj.AddComponent<PauseMenu>();
        pauseMenu.pauseGameMenu = new GameObject();
    }

    [Test]
    public void PauseAndResume_TogglesStates()
    {
        pauseMenu.Pause();
        Assert.IsTrue(pauseMenu.pauseGameMenu.activeSelf);
        Assert.AreEqual(0f, Time.timeScale);
        Assert.IsTrue(pauseMenu.PauseGame);

        pauseMenu.Resume();
        Assert.IsFalse(pauseMenu.pauseGameMenu.activeSelf);
        Assert.AreEqual(1f, Time.timeScale);
        Assert.IsFalse(pauseMenu.PauseGame);
    }
}