using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultName", menuName = "Variable Holders/Int Single Stat")]
public class Int_Single_Stat_Script : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialisedVariable;
    //[System.NonSerialized]
    public int runVariable;

    public delegate void OnIntUpdateHandle();
    public event OnIntUpdateHandle OnIntUpdate;

    public void OnAfterDeserialize()
    {
        runVariable = initialisedVariable;
    }

    public void OnBeforeSerialize() { }
    

}
