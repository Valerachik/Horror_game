using UnityEngine;
using Photon.Pun;
using SojaExiles;

public class IsMine : MonoBehaviour
{

    [SerializeField] private PlayerMovment _playerMovement;
    [SerializeField] private MouseLook _mouseLook;
    [SerializeField] private GameObject _camera;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private GameObject _playerModel;

    void Start()
    {
        if (!_photonView.IsMine)
        {
            _playerMovement.enabled = false;
            _mouseLook.enabled = false;
            _camera.SetActive(false);
            _playerModel.SetActive(true);
        }
    }

}