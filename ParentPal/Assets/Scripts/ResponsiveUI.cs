using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ResponsiveUI : MonoBehaviour
{
    private int screenWidth, screenHeight;
    private int minButtonHeight, maxButtonHeight;
    private float titleShare, textShare, buttonShare, imageShare;

    public RectTransform scenarioScroll, scenarioTitle, scenarioTextBox, scenarioImage;
    public Text scenarioText;
    public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        GrabScreenSize();

        minButtonHeight = 50;
        maxButtonHeight = 200;

        // The percentage shares each element should take up of the screen.
        // These values should add up to 1!
        titleShare = 0.1f;
        textShare = 0.5f;
        buttonShare = 0.4f;
        //Vertical screen percantage for the image.
        imageShare = 0.4f;

        setup();
    }

    // Function to setup the main parts of the UI
    private void setup()
    {
        RectTransform mainPanel = GetComponent<RectTransform>();

        // Resize the background to match the phone's resolution.
        mainPanel.sizeDelta = new Vector2(screenWidth, screenHeight);

        // Resize the scenario's text box to the correct proportions and position.
        scenarioScroll.sizeDelta = new Vector2(screenWidth * (1 - imageShare), screenHeight * textShare);
        scenarioScroll.anchoredPosition = new Vector2(-(screenWidth * ((1 - imageShare) * 0.5f)), -(screenHeight * titleShare) - (scenarioScroll.sizeDelta.y * 0.5f));

        // Resize the scenario's image to the correct proportions and position.
        scenarioImage.sizeDelta = new Vector2(screenWidth * imageShare, screenHeight * textShare);
        scenarioImage.anchoredPosition = new Vector2(screenWidth * (imageShare * 0.5f), -(screenHeight * titleShare) - (scenarioImage.sizeDelta.y * 0.5f));

        // Move the scenario's title to the correct position.
        scenarioTitle.sizeDelta = new Vector2(screenWidth, screenHeight * titleShare);
        scenarioTitle.anchoredPosition = new Vector2(0, -(screenHeight * (titleShare * 0.5f)));
    }

    // Function to grab the size of the screen.
    private void GrabScreenSize()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Function to setup the buttons for the current scenario.
    public void SetupButtons(List<GameObject> scenarioButtons)
    {
        GrabScreenSize();
        buttons = scenarioButtons;

        // Loop through all of the buttons:
        for (int i = 0; i < buttons.Count; i++)
        {
            RectTransform buttonTransform = buttons[i].GetComponent<RectTransform>();

            // Resize the button's to correct proportions.
            float buttonHeight = Mathf.Clamp((screenHeight * buttonShare) / (buttons.Count + 1), minButtonHeight, maxButtonHeight);
            float buttonWidthScale = 0.75f;
            buttonTransform.sizeDelta = new Vector2(screenWidth * buttonWidthScale, buttonHeight);

            // Move the buttons to the correct positions.
            float ySpacing = buttonHeight / (buttons.Count + 1);
            float y = ((buttonHeight * ((buttons.Count + 1) - i)) - (ySpacing * (i + 1))) - (buttonHeight * 0.5f);
            buttonTransform.anchoredPosition = new Vector3(0f, y, 0f);
        }
    }

    public void ResizeTextBox()
    {
        int lines = Mathf.CeilToInt(scenarioText.text.Length / 20);
        scenarioTextBox.sizeDelta = new Vector2(scenarioTextBox.sizeDelta.x, lines * 55);
    }
}
