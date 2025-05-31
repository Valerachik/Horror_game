using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovment : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 5.0f;
    public float runSpeed = 7.0f;

    public float crouchHeight = 1.0f;
    public float standHeight = 2.0f;
    public Vector3 crouchCenter = new Vector3(0, 0.5f, 0);
    public Vector3 standCenter = new Vector3(0, 1.0f, 0);

    private CharacterController controller;
    private bool isCrouching = false;

    private void Start()
    {
        if (!photonView.IsMine) return;

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        HandleCrouch();
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y -= 9.81f * Time.deltaTime;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = isRunning ? runSpeed : moveSpeed;

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                controller.height = crouchHeight;
                controller.center = crouchCenter;
            }
            else
            {
                controller.height = standHeight;
                controller.center = standCenter;
            }
        }
    }
}