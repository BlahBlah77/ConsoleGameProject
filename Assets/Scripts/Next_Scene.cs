using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene : MonoBehaviour {

    public string startGameScene;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(LoadSceneAsynchronously(startGameScene));
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
