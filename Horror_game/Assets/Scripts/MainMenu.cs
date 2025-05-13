using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game_alone");
    }
    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
