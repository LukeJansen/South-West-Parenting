using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ResponsiveUI : MonoBehaviour
{
    private int screenWidth, screenHeight;
    private int direction;

    public RectTransform scenarioText;
    public List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        GrabScreenSize();

        Debug.Log("Width: " + screenWidth + ", Height: " + screenHeight);

        setup();

        direction = -10;
    }

    private void setup()
    {
        RectTransform mainPanel = GetComponent<RectTransform>();
        mainPanel.sizeDelta = new Vector2(screenWidth, screenHeight);
        scenarioText.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.3f);
        scenarioText.anchoredPosition = new Vector2(-(screenWidth * 0.4f), -450);
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

            buttonTransform.sizeDelta = new Vector2(screenWidth * 0.75f, (screenHeight * 0.3f) / (buttons.Count + 1));

            float y = ((screenHeight / 3) / (buttons.Count)) * (buttons.Count - (i - 1));
            buttonTransform.anchoredPosition = new Vector3(0, y, 0);
        }
    }
}
