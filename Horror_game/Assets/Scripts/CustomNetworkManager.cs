using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
    public InputField roomNameInput;

    public void HostGame()
    {
        StartHost();
        Debug.Log("Хост стартував");
    }

    public void JoinGame()
    {
        networkAddress = roomNameInput.text;
        StartClient();
        Debug.Log("Підключення до: " + networkAddress);
    }
}