using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class UI_Manager : MonoBehaviour
{

    private static UI_Manager current = null;
    public EventManager eventmanager;

    [Header("UI Panels")]
    public RectTransform pausePanel;
    public RectTransform inventoryPanel;
    public RectTransform gameOverPanel;
    public RectTransform currentPanel;
    public RectTransform dialoguePanel;
    public RectTransform shopPanel;
    public RectTransform questPanel;

    private UnityAction pauseListen;

    [Header("Stored Player Stats")]
    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;
    public Int_Stat_Script playerMoney;
    public Int_Stat_Script playerHealth;

    [Header("UI Variables")]
    public string menuScene;

    [Header("UI Elements")]
    public Text lvlText;
    public Text coinText;
    public Text speechDialogueText;
    public Text nameDialogueText;
    public Text nameShopText;
    public Text questText;
    public Slider xpSlider;
    public Slider healthSlider;
    public Button dialogueNextButton;
    public Button dialogueFirstOptionButton;
    public Button dialogueSecondOptionButton;

    Game_Manager gmRef;

    private int storedMoneyReq;
    private string levelToLoad;

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
        playerXP.OnIntUpdate += XPSliderSet;
        playerHealth.OnIntUpdate += HealthSliderSet;
    }

    private void Start()
    {
        MaxSliderSet(playerXP.runVariable2);
        XPSliderSet(playerXP.runVariable);
        LevelTextSet(playerLevel.runVariable);
        healthSlider.maxValue = playerHealth.runVariable2;
        HealthSliderSet(playerHealth.runVariable);
        Event_Manager_Luke.StartListen("PauseToggle", PauseActivate);
        Event_Manager_Luke.StartListen("InventToggle", InventoryActivate);
        playerXP.OnIntUpdate2 += MaxSliderSet;
        playerLevel.OnIntUpdate += LevelTextSet;
        eventmanager.OnAnyCoinCollected += Eventmanager_OnAnyCoinCollected;
        gmRef = Game_Manager.Instance;
    }

    private void OnDestroy()
    {
        playerXP.OnIntUpdate -= XPSliderSet;
        playerLevel.OnIntUpdate -= LevelTextSet;
        playerXP.OnIntUpdate2 -= MaxSliderSet;
        eventmanager.OnAnyCoinCollected -= Eventmanager_OnAnyCoinCollected;
    }

    private void Eventmanager_OnAnyCoinCollected(object sender, EventArgs e)
    {
        if (playerMoney.runVariable < playerMoney.runVariable2)
        {
            playerMoney.runVariable++;
            coinText.text = "Coins: " + playerMoney.runVariable;
        }
        else
        {
            playerMoney.runVariable = playerMoney.runVariable2;
            coinText.text = "Coins: " + playerMoney.runVariable;
            Debug.Log("You have collected the max coins");
        }
    }

    void CollectStartUIObjects()
    {
        pausePanel.gameObject.SetActive(false);
        inventoryPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    void HealthSliderSet(int value)
    {
        healthSlider.value = value;
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

    public void InventoryActivate()
    {
        if (!gmRef.isPaused)
        {
            EnableUIPanel(inventoryPanel);
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

    public void EnableUIPanel_Shop(RectTransform newPanel, string shopName, Item_List_Script shopContents)
    {
        Shop_Menu_UI tempMenu = newPanel.GetComponent<Shop_Menu_UI>();
        tempMenu.shopList = shopContents;
        nameShopText.text = shopName;
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

    public void EnableUIPanel_Quest(RectTransform newPanel, string dialogue, string levelID, int moneyReq)
    {
        storedMoneyReq = moneyReq;
        questText.text = dialogue;
        levelToLoad = levelID;
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

    public void LoadNewLevel()
    {
        if (levelToLoad != null && playerMoney.runVariable >= storedMoneyReq) StartCoroutine(LoadSceneAsynchronously(levelToLoad));
    }

    void XPSliderSet(int value)
    {
        Debug.Log(value);
        if (playerXP.runVariable < playerXP.runVariable2) xpSlider.value = value;
    }

    void MaxSliderSet(int value)
    {
        xpSlider.maxValue = value;
    }

    void LevelTextSet(int value)
    {
        lvlText.text = value.ToString();
    }

    public void MainMenu()
    {
        StartCoroutine(LoadSceneAsynchronously(menuScene));
    }

    public void BackToHub()
    {
        //if (gmRef.isGameOver)
        //{
            playerHealth.IntSetValChanger(playerHealth.runVariable2);
            gmRef.isGameOver = false;
        //}
        StartCoroutine(LoadSceneAsynchronously("lvl_hub"));
    }

    public void RetryLevel()
    {
        if (gmRef.isGameOver)
        {
            playerHealth.IntSetValChanger(playerHealth.runVariable2);
            gmRef.isGameOver = false;
        }
        StartCoroutine(LoadSceneAsynchronously(SceneManager.GetActiveScene().name));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadSceneAsynchronously(string newLevel)
    {
        AsyncOperation aOp = SceneManager.LoadSceneAsync(newLevel);
        while (!aOp.isDone)
        {
            yield return null;
        }
    }

    public void DialogueName(string name)
    {
        nameDialogueText.text = name;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
    }

    public IEnumerator DialogueAutoType(string dialogue)
    {
        speechDialogueText.text = "";
        foreach (char dialogueLetter in dialogue.ToCharArray())
        {
            speechDialogueText.text += dialogueLetter;
            yield return null;
        }
    }

    public void ButtonTextChanger(string firstOption, string secondOption)
    {
        dialogueFirstOptionButton.GetComponentInChildren<Text>().text = firstOption;
        dialogueSecondOptionButton.GetComponentInChildren<Text>().text = secondOption;
    }
}