using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ResponsiveUI : MonoBehaviour
{
    private int screenWidth, screenHeight;
    public RectTransform text;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        Debug.Log("Width: " + screenWidth + ", Height: " + screenHeight);

        setup();

        direction = -10;
    }

    private void setup()
    {
        RectTransform mainPanel = GetComponent<RectTransform>();
        mainPanel.sizeDelta = new Vector2(screenWidth, screenHeight);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(text.anchoredPosition);
        if (text.anchoredPosition.y < -(screenHeight - 75)) direction = 10;
        if (text.anchoredPosition.y > -75) direction = -10;

        text.Translate(new Vector3(0, direction));
    }
}
