using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Level : MonoBehaviour {

    public string levelName;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(UI_Manager.Current.LoadSceneAsynchronously(levelName));
    }
}
