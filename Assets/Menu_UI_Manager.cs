using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_UI_Manager : MonoBehaviour {

    public string startGameScene;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneAsynchronously(startGameScene));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneAsynchronously(string newLevel)
    {
        AsyncOperation aOp = SceneManager.LoadSceneAsync(newLevel);
        while (!aOp.isDone)
        {
            yield return null;
        }
    }
}
