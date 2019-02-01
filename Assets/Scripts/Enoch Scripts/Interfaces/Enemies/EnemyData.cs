using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDataclass
{
    public float EnemyHealth = 100;
    public float damageToTake = 10f;
    public float enemyAttackPower = 5f;
}

[CreateAssetMenu]
public class EnemyData : ScriptableObject {

    public EnemyDataclass _enemyData;
}
