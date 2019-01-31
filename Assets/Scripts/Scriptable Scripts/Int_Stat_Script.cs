using UnityEngine;

[CreateAssetMenu(fileName = "DefaultName", menuName = "Variable Holders/Int Stat")]
public class Int_Stat_Script : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialisedVariable;
    [System.NonSerialized]
    public int runVariable;

    public delegate void OnIntUpdateHandle(int newValue);
    public event OnIntUpdateHandle OnIntUpdate;

    public void OnAfterDeserialize()
    {
        runVariable = initialisedVariable;
    }

    public void OnBeforeSerialize() { }

    public void IntPlusChanger(int newValue)
    {
        runVariable += newValue;
        if (OnIntUpdate != null)
        {
            OnIntUpdate(runVariable);
        }
    }

    public void IntSetValChanger(int newValue)
    {
        runVariable = newValue;
        if (OnIntUpdate != null)
        {
            OnIntUpdate(runVariable);
        }
    }

    public void IntMinusChanger(int newValue)
    {
        runVariable -= newValue;
        if (OnIntUpdate != null)
        {
            OnIntUpdate(runVariable);
        }
    }
}
