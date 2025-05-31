using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreamer : MonoBehaviour
{
    public Transform lookTarget; // Об'єкт, у бік якого має повернутись гравець
    public string menuSceneName = "Menu"; // Назва сцени меню

    private bool activated = false;

    private void OnMouseDown()
    {
        if (activated) return; // Щоб не викликати кілька разів
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

            // Завантаження сцени через 5 секунд
            Invoke(nameof(LoadMenuScene), 5f);
        }
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
