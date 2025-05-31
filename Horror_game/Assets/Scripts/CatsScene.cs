using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneTrigger : MonoBehaviour
{
    public string nextSceneName;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}