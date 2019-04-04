using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossUIManager : MonoBehaviour {

    [Header("UI Panels")]
    public RectTransform victoryPanel;
    public RectTransform currentPanel;

    [Header("UI Text")]
    public Text lvlText;
    public Text moneyText;

    [Header("Stored Player Stats")]
    public Int_Stat_Script playerLevel;
    public Int_Stat_Script playerMoney;

    public void EnableUIPanel(RectTransform newPanel)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        if (currentPanel != null)
        {
            currentPanel.gameObject.SetActive(true);
        }
        moneyText.text = playerMoney.runVariable.ToString();
        lvlText.text = playerLevel.runVariable.ToString();
        newPanel.gameObject.SetActive(true);
        currentPanel = newPanel;
    }
}
