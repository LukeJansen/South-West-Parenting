using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ResponsiveUI : MonoBehaviour
{
    private int screenWidth, screenHeight;

    public RectTransform scenarioText, scenarioTitle;
    public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        GrabScreenSize();

        Debug.Log("Width: " + screenWidth + ", Height: " + screenHeight);

        setup();
    }

    private void setup()
    {
        RectTransform mainPanel = GetComponent<RectTransform>();
        mainPanel.sizeDelta = new Vector2(screenWidth, screenHeight);
        scenarioText.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.3f);
        scenarioText.anchoredPosition = new Vector2(-(screenWidth * 0.4f), -(screenHeight * 0.2f));
        scenarioTitle.anchoredPosition = new Vector2(0, -(screenHeight * 0.1f));
    }

    private void GrabScreenSize()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    public void SetupButtons(List<GameObject> scenarioButtons)
    {
        GrabScreenSize();
        buttons = scenarioButtons;

        for (int i = 1; i < buttons.Count + 1; i++)
        {
            RectTransform buttonTransform = buttons[i - 1].GetComponent<RectTransform>();

            float buttonHeight = Mathf.Clamp((screenHeight * 0.5f) / (buttons.Count + 1), 100, 200);

            buttonTransform.sizeDelta = new Vector2(screenWidth * 0.75f, buttonHeight);

            float ySpacing = buttonHeight / (buttons.Count);

            float y = (buttonHeight * ((buttons.Count) - (i - 1))) + ySpacing;

            buttonTransform.anchoredPosition = new Vector3(0f, y, 0f);
        }
    }
}
