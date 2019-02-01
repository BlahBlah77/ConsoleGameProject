using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{

    private static UI_Manager current = null;

    [Header("UI Panels")]
    public RectTransform pausePanel;
    public RectTransform gameOverPanel;
    public RectTransform currentPanel;

    private UnityAction pauseListen;

    [Header("Stored Player Stats")]
    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;

    [Header("UI Elements")]
    public Text lvlText;
    public Slider xpSlider;

    Game_Manager gmRef;

    public static UI_Manager Current
    {
        get
        {
            return current;
        }
    }

    void Awake()
    {
        current = this;
        CollectStartUIObjects();
        DisableUIPanel();
    }

    private void Start()
    {
        Event_Manager_Luke.StartListen("PauseToggle", PauseActivate);
        playerXP.OnIntUpdate += SliderSet;
        playerLevel.OnIntUpdate += TextSet;
        gmRef = Game_Manager.Instance;
    }

    private void OnDestroy()
    {
        playerXP.OnIntUpdate -= SliderSet;
        playerLevel.OnIntUpdate -= TextSet;
    }

    void CollectStartUIObjects()
    {
        pausePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    public void PauseActivate()
    {
        if (!gmRef.isPaused)
        {
            EnableUIPanel(pausePanel);
        }
        else
        {
            DisableUIPanel();
        }
    }

    public void GMActivate()
    {
        EnableUIPanel(gameOverPanel);
    }

    public void DisableUIPanel()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        if (currentPanel != null)
        {
            currentPanel.gameObject.SetActive(false);
            currentPanel = null;
        }
    }
    
    public void EnableUIPanel(RectTransform newPanel)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        if (currentPanel != null)
        {
            currentPanel.gameObject.SetActive(true);
        }
        newPanel.gameObject.SetActive(true);
        currentPanel = newPanel;
    }

    void SliderSet(int value)
    {
        xpSlider.value = value;
    }

    void TextSet(int value)
    {
        lvlText.text = value.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
