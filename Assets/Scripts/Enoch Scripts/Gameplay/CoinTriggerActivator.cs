using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTriggerActivator : MonoBehaviour {

	

    public void ActivateCoin()
    {
        this.GetComponent<Collider>().isTrigger = true;
    }
}
