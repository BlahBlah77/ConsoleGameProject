using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Misc/Dialogue")]
public class Dialogue_Segment : ScriptableObject
{
    public List<Dialogue_Segment> choiceLists;
    public string dialogueName;
    public string dialogueOptionName;
    [TextArea(2, 5)] public string[] dialogueLines;
}
