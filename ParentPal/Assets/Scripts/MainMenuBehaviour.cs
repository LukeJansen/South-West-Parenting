using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public RectTransform mainPanel, menuTitle, playPanel, CharacterEditorPanel, playButton, characterEditorButton;

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
        //playButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);

        playPanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.35f);
        CharacterEditorPanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.35f);

        playButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);
        characterEditorButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);

        playPanel.position = new Vector3(screenWidth / 2, ((screenHeight / 2) + screenHeight * 0.2f));
        CharacterEditorPanel.position = new Vector3(screenWidth / 2, ((screenHeight / 2) - screenHeight * 0.2f));
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadCharacterEditor()
    {
        SceneManager.LoadScene(4);
    }
}