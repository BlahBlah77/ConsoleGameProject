using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Destroy : MonoBehaviour {

    public float destroyTime = 2f;

    void OnEnable()
    {
        Invoke("DisableAndDestroy", destroyTime);
    }

    virtual public void DisableAndDestroy()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
