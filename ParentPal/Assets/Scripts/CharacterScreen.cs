using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScreen : MonoBehaviour
{
    public RectTransform menuTitle, characterOnePanel, characterTwoPanel, characterThreePanel, characterOneButton, characterTwoButton, characterThreeButton;

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

        characterOnePanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.20f);
        characterTwoPanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.20f);
        characterThreePanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.20f);


        characterOneButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);
        characterTwoButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);
        characterThreeButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);


        characterOnePanel.position = new Vector3(screenWidth / 2, ((screenHeight / 2) + screenHeight * 0.25f));
        characterTwoPanel.position = new Vector3(screenWidth / 2, (screenHeight / 2));
        characterThreePanel.position = new Vector3(screenWidth / 2, ((screenHeight / 2) - screenHeight * 0.25f));

    }

    public void LoadCharacterCreation()
    {
        SceneManager.LoadScene(1);
    }
}
