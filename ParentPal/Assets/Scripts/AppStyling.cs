using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStyling : MonoBehaviour
{
    private Color buttonColour;
    private Color cardColour;
    private Color backgroundColour;

    [SerializeField]
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        buttonColour = new Color(88, 204, 249);
        cardColour = new Color(0.741f, 0.913f, 0.992f);
        backgroundColour = new Color(1, 1, 1, 1);

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
