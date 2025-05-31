using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviourPunCallbacks
{
    [SerializeField] private string sceneName;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    
    void Update()
    {
        SceneManager.LoadScene(sceneName);
    }
}
