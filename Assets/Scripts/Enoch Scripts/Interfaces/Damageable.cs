using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    // function to determine how much damage is taken
    void TakeDamage(float damage);

    // getter and setter for damage taken
    //float getDamageRecieved { get; set; }
}
