using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenBehaviour : MonoBehaviour
{
    public RectTransform optionText, optionTitle;
    public Text text;
    
    private float screenWidth, screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        GrabScreenSize();
        Setup();
        OptionText();
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
        optionTitle.anchoredPosition = new Vector2(0, -screenHeight * 0.1f);
        optionText.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.8f);
        optionText.anchoredPosition = new Vector2(0, -screenHeight * 0.1f);
    }

    private void OptionText()
    {
        List<Option> options = GameObject.Find("Data").GetComponent<DataHolder>().chosenOptions;

        for (int i = 0; i < options.Count; i++)
        {
            text.text += options[i].Text + System.Environment.NewLine;
        }
    }
}
