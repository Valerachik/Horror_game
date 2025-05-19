using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class NetworkConnector : MonoBehaviour
{
    public InputField ipInputField;

    public void ConnectToServer()
    {
        string ip = ipInputField.text;
        NetworkManager.singleton.networkAddress = ip;
        NetworkManager.singleton.StartClient();
    }
}
