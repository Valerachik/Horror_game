using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity);
    }
    
}
