using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour, IDamager {

    public float DoDamage()
    {
        return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if i hit anything that implemets the iDamageable
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("You are hit");
            damageable.TakeDamage(); // the thing that is hit with the interface will take damage to its health
        }
    }
}
