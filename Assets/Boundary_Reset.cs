using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_Reset : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        UI_Manager.Current.RetryLevel();
    }
}
