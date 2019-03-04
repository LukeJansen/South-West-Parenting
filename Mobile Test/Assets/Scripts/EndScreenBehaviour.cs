using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenBehaviour : MonoBehaviour
{
    public RectTransform optionText;
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
        optionText.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.3f);
        //optionText.anchoredPosition = new Vector2(-(screenWidth * 0.4f), -450);
    }

    private void OptionText()
    {
        Debug.Log(GameObject.Find("Data").GetComponent<DataHolder>().chosenOptions);
        List<Option> options = GameObject.Find("Data").GetComponent<DataHolder>().chosenOptions;

        for (int i = 0; i < options.Count; i++)
        {
            text.text += options[i].Text + System.Environment.NewLine;
        }
    }
}
