using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true; 
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master!");
        SceneManager.LoadScene("Menu"); 
    }
}