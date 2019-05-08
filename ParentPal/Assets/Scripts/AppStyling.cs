using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStyling : MonoBehaviour
{
    private Color buttonColour;
    [SerializeField]
    private Color cardColour;
    private Color backgroundColour;

    [SerializeField]
    private Canvas canvas;

    void Awake()
    {
        buttonColour = new Color(0.345f, 0.8f, 0.976f);
        cardColour = new Color(0.741f, 0.913f, 0.992f, 1f);
        backgroundColour = new Color(1f, 1f, 1f, 1f);

        //SetColours(canvas);
    }

    //private void SetColours(Canvas canvas)
    //{

    //}

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
