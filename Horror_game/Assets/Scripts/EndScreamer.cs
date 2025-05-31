using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreamer : MonoBehaviour
{
    public Transform lookTarget; 
    public string menuSceneName = "Menu";
    public GamePhase nextPhase;
    private bool activated = false;

    private void OnMouseDown()
    {
        if (activated) return;
        activated = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && lookTarget != null)
        {
            Vector3 direction = (lookTarget.position - player.transform.position).normalized;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                player.transform.rotation = Quaternion.LookRotation(direction);
            }

            Invoke(nameof(LoadMenuScene), 5f);
        }
    }

    private void LoadMenuScene()
    {
        SceneManager3D.Instance.AdvancePhase(nextPhase);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(menuSceneName);
    }
}
