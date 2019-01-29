using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    // function to determine how much damage is given to something
    float DoDamage();

    // getter and setter for damage taken
    //float getDamageTaken { get; set; }
}

