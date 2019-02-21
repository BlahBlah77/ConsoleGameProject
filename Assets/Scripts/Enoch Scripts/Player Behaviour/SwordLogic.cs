using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//CODE COMBINED WITH WEAPON_SCRIPT
public class SwordLogic : MonoBehaviour, IDamager {

    public float DoDamage()
    {
        return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if i hit anything that implemets the iDamageable
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        float flaot = DoDamage();
        if (damageable != null)
        {
            Debug.Log("You are hit");
            damageable.TakeDamage(flaot); // the thing that is hit with the interface will take damage to its health
        }
    }
}
