using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppStyling : MonoBehaviour
{
    private Color buttonColour;
    [SerializeField]
    private Color cardColour;
    private Color backgroundColour;

    [SerializeField]
    private Sprite backgroundSprite;
    [SerializeField]
    private Sprite buttonSprite;
    [SerializeField]
    private Sprite cardSprite;
    [SerializeField]
    private Sprite crossButtonSprite;
    [SerializeField]
    private Sprite homeButtonSprite;

    private Image[] mainCameraChildren;
    

    void Awake()
    {
        buttonColour = new Color(0.345f, 0.8f, 0.976f);
        cardColour = new Color(0.741f, 0.913f, 0.992f, 1f);
        backgroundColour = new Color(1f, 1f, 1f, 1f);

        Debug.Log(backgroundSprite);
    }

    void Start()
    {
        Invoke("UpdateAppStyling", 0.001f);
    }

    public void UpdateAppStyling()
    {

        Debug.Log("update app styling called");

        mainCameraChildren = GetComponentsInChildren<Image>();

        foreach (Image child in mainCameraChildren)
        {

            if (child.tag == "background")
            {
                child.GetComponent<Image>().sprite = backgroundSprite;
            }
            else if (child.tag == "card")
            {
                child.GetComponent<Image>().sprite = cardSprite;
            }
            else if (child.tag == "button")
            {
                child.GetComponent<Image>().sprite = buttonSprite;
            }
            else if (child.tag == "homeButton")
            {
                child.GetComponent<Image>().sprite = crossButtonSprite;
            }
            else if (child.tag == "crossButton")
            {
                child.GetComponent<Image>().sprite = homeButtonSprite;
            }
        }

    }

    private void SetColours(Canvas canvas)
    {

    }

    public Color ButtonColour {
        get
        {
            return buttonColour;
        }
    }

    public Color CardColour
    {
        get
        {
            return cardColour;
        }
    }

    public Color BackgroundColour
    {
        get
        {
            return backgroundColour;
        }
    }

}
