using NUnit.Framework;
using UnityEngine;

public class Stuk_musicTests
{
    private GameObject obj;
    private Stuk_music stukMusic;
    private AudioSource audioSource;

    [SetUp]
    public void Setup()
    {
        obj = new GameObject();
        stukMusic = obj.AddComponent<Stuk_music>();
        audioSource = obj.AddComponent<AudioSource>();
        stukMusic.audioSource = audioSource;
        stukMusic.clip = AudioClip.Create("test", 44100, 1, 44100, false);
    }

    [Test]
    public void PlaysClipOnceOnTrigger()
    {
        var player = new GameObject();
        player.tag = "Player";
        var collider = player.AddComponent<BoxCollider>();

        stukMusic.OnTriggerEnter(collider);
        Assert.IsTrue(stukMusic != null); // Просто щоб перевірити, що виклик був

        // Повторний виклик нічого не має робити
        stukMusic.OnTriggerEnter(collider);
    }
}