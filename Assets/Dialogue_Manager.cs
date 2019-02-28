using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Manager : MonoBehaviour {

    private static Dialogue_Manager instance;

    Queue<string> dialogueLinesInput;
    Dialogue_Segment currentDialogue;
    public Dialogue_Segment firstOptionDialogue;
    public Dialogue_Segment secondOptionDialogue;

    UI_Manager uiReference;

    public static Dialogue_Manager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        dialogueLinesInput = new Queue<string>();
    }

    private void Start()
    {
        uiReference = UI_Manager.Current;
    }

    public void DialogueStart(Dialogue_Segment dialogue)
    {
        currentDialogue = dialogue;
        ResponseChecker();
        uiReference.dialoguePanel.gameObject.SetActive(true);
        uiReference.DialogueName(dialogue.dialogueName);
        dialogueLinesInput.Clear();
        foreach (string line in dialogue.dialogueLines)
        {
            dialogueLinesInput.Enqueue(line);
        }
        DialogueDisplayer();
    }

    public void DialogueDisplayer()
    {
        ResponseChecker();
        if (dialogueLinesInput.Count == 0)
        {
            DialogueQuit();
            return;
        }
        string newSpeechLine = dialogueLinesInput.Dequeue();
        StopAllCoroutines();
        StartCoroutine(uiReference.DialogueAutoType(newSpeechLine));
    }

    public void DialogueQuit()
    {
        uiReference.dialoguePanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public void DialogueNextFirst()
    {
        DialogueStart(firstOptionDialogue);
    }

    public void DialogueNextSecond()
    {
        DialogueStart(secondOptionDialogue);
    }

    void ResponseChecker()
    {
        if (currentDialogue.choiceLists.Count > 0)
        {
            if (dialogueLinesInput.Count > 1)
            {

                uiReference.dialogueNextButton.gameObject.SetActive(true);
                uiReference.dialogueFirstOptionButton.gameObject.SetActive(false);
                uiReference.dialogueSecondOptionButton.gameObject.SetActive(false);
            }
            else
            {
                firstOptionDialogue = currentDialogue.choiceLists[0];
                secondOptionDialogue = currentDialogue.choiceLists[1];
                uiReference.dialogueNextButton.gameObject.SetActive(false);
                uiReference.dialogueFirstOptionButton.gameObject.SetActive(true);
                uiReference.dialogueSecondOptionButton.gameObject.SetActive(true);
            }
        }
        else
        {
            uiReference.dialogueNextButton.gameObject.SetActive(true);
            uiReference.dialogueFirstOptionButton.gameObject.SetActive(false);
            uiReference.dialogueSecondOptionButton.gameObject.SetActive(false);
        }
    }
}
