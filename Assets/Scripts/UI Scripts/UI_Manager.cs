﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    private static UI_Manager current = null;

    [Header("UI Panels")]
    public RectTransform pausePanel;
    public RectTransform gameOverPanel;
    public RectTransform currentPanel;

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

    void CollectStartUIObjects()
    {
        pausePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
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

    public void ExitGame()
    {
        Application.Quit();
    }
}
