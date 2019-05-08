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

    private Sprite backgroundSprite;
    private Sprite buttonSprite;
    private Sprite cardSprite;
    private Sprite crossButtonSprite;
    private Sprite homeButtonSprite;

    private Image[] mainCameraChildren;

    [SerializeField]
    private GameObject panel;

    void Awake()
    {
        //backgroundSprite = (Sprite)Resources.Load(@"Assets/Resources/blue_button11.png");
        //buttonSprite = (Sprite)Resources.Load("Assets/ThirdPartyAssets/uipack_fixed/PNG/blue_button11.png");
        //cardSprite = (Sprite)Resources.Load("Assets/ThirdPartyAssets/uipack_fixed/PNG/blue_button11.png");
        //crossButtonSprite = (Sprite)Resources.Load("Assets/ThirdPartyAssets/uipack_fixed/PNG/blue_button11.png");
        //homeButtonSprite = (Sprite)Resources.Load("Assets/ThirdPartyAssets/uipack_fixed/PNG/blue_button11.png");

        buttonColour = new Color(0.345f, 0.8f, 0.976f);
        cardColour = new Color(0.741f, 0.913f, 0.992f, 1f);
        backgroundColour = new Color(1f, 1f, 1f, 1f);

        Debug.Log(backgroundSprite);

        //SetColours(canvas);
    }

    //void Start()
    //{
    //    Invoke("UpdateAppStyling", 0.1f);
    //}

    //public void UpdateAppStyling()
    //{
    //    //mainCameraChildren = new List<RectTransform>();

    //    Debug.Log("update app styling called");

    //    mainCameraChildren = GetComponentsInChildren<Image>();

    //    foreach(Image child in mainCameraChildren)
    //    {
    //        //GameObject child = obj.GetComponent<GameObject>();

    //        if(child.tag == "background")
    //        {
    //            panel.GetComponent<Image>().overrideSprite = backgroundSprite;
    //        }
    //        else if(child.tag == "card")
    //        {
    //            child.GetComponent<Image>().sprite = buttonSprite;
    //        }
    //        else if(child.tag == "button")
    //        {
    //            child.GetComponent<Image>().sprite = cardSprite;
    //        }
    //        else if (child.tag == "homeButton")
    //        {
    //            child.GetComponent<Image>().sprite = crossButtonSprite;
    //        }
    //        else if (child.tag == "crossButton")
    //        {
    //            child.GetComponent<Image>().sprite = homeButtonSprite;
    //        }

            
    //    }

    //}

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
