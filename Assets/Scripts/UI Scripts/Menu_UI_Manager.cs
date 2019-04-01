using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_UI_Manager : MonoBehaviour {

    public string startGameScene;
    
    public Material menuMat;
    public AudioSource audSource;
    public Slider volumeSlider;

    [Header("UI Panels")]
    public RectTransform currentPanel;
    public RectTransform mainPanel;
    public RectTransform optionsPanel;


    private void Awake()
    {
        audSource = GetComponent<AudioSource>();
        RenderSettings.skybox = menuMat;
        currentPanel = mainPanel;
    }

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;
        Time.timeScale = 1.0f;
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneAsynchronously(startGameScene));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainPanelEnable()
    {
        EnableUIPanel(mainPanel);
    }

    public void OptionPanelEnable()
    {
        EnableUIPanel(optionsPanel);
    }

    public void EnableUIPanel(RectTransform newPanel)
    {
        if (currentPanel != null)
        {
            currentPanel.gameObject.SetActive(false);
        }
        newPanel.gameObject.SetActive(true);
        currentPanel = newPanel;
    }

    public void SaveOptions()
    {
        Game_Manager.Instance.OptionSave();
    }

    public void VolumeAdjustment(Slider slider)
    {
        //Takes slider value and applies it to volume
        AudioListener.volume = slider.value;
    }

    IEnumerator LoadSceneAsynchronously(string newLevel)
    {
        AsyncOperation aOp = SceneManager.LoadSceneAsync(newLevel);
        while (!aOp.isDone)
        {
            yield return null;
        }
    }
}
