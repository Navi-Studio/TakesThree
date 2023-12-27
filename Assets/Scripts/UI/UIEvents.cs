using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{

    
    public void NewGameEvent()
    {
        SceneManager.LoadScene("MainScene");
        string currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(UnloadSceneAsync(currentSceneName));
    }
    
    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
        yield return null;
    }

    public void ExitGameEvent()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
