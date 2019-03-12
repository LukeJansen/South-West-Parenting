﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public RectTransform menuTitle, menuButton;

    private float screenWidth, screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        GrabScreenSize();
        Setup();
    }

    private void GrabScreenSize()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Setup()
    {
        RectTransform mainPanel = GetComponent<RectTransform>();
        mainPanel.sizeDelta = new Vector2(screenWidth, screenHeight);
        menuTitle.anchoredPosition = new Vector2(0, -screenHeight * 0.1f);
        menuButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);

    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}