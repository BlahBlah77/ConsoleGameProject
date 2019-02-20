using UnityEngine;

[CreateAssetMenu(fileName = "DefaultName", menuName = "Variable Holders/Int Stat")]
public class Int_Stat_Script : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialisedVariable;
    public int initialisedVariable2;
    //[System.NonSerialized]
    public int runVariable;
    //[System.NonSerialized]
    public int runVariable2;

    public delegate void OnIntUpdateHandle(int newValue);
    public event OnIntUpdateHandle OnIntUpdate;
    public event OnIntUpdateHandle OnIntUpdate2;

    public void OnAfterDeserialize()
    {
        runVariable = initialisedVariable;
        runVariable2 = initialisedVariable2;
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

    public void SecondIntSetValChanger(int newValue)
    {
        runVariable2 = newValue;
        if (OnIntUpdate2 != null)
        {
            OnIntUpdate2(runVariable2);
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
