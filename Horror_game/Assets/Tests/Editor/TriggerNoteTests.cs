using NUnit.Framework;
using UnityEngine;

public class TriggerNoteTests
{
    private GameObject triggerObj;
    private TriggerNote triggerNote;

    [SetUp]
    public void Setup()
    {
        triggerObj = new GameObject();
        triggerNote = triggerObj.AddComponent<TriggerNote>();
        triggerNote.nextPhase = GamePhase.Sleep;

        var smObj = new GameObject();
        var sm = smObj.AddComponent<SceneManager3D>();
        SceneManager3D.Instance = sm;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(triggerObj);
        Object.DestroyImmediate(SceneManager3D.Instance.gameObject);
    }

    [Test]
    public void OnTriggerEnter_WithPlayer_AdvancesPhaseOnce()
    {
        var player = new GameObject();
        player.tag = "Player";
        var collider = player.AddComponent<BoxCollider>();

        triggerNote.OnTriggerEnter(collider);
        Assert.AreEqual(GamePhase.Sleep, SceneManager3D.Instance.CurrentPhase);

        // Повторний виклик нічого не змінює
        triggerNote.OnTriggerEnter(collider);
        Assert.AreEqual(GamePhase.Sleep, SceneManager3D.Instance.CurrentPhase);

        Object.DestroyImmediate(player);
    }
}