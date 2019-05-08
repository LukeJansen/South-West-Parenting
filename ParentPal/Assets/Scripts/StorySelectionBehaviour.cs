using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySelectionBehaviour : MonoBehaviour
{
    public RectTransform menuTitle, storyOnePanel, storyTwoPanel, storyOneButton, storyTwoButton;

    private float screenWidth, screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        GrabScreenSize();
        Setup();
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
        menuTitle.anchoredPosition = new Vector2(0, -screenHeight * 0.1f);

        storyOnePanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.35f);
        storyTwoPanel.sizeDelta = new Vector2(screenWidth * 0.8f, screenHeight * 0.35f);

        storyOneButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);
        storyTwoButton.sizeDelta = new Vector2(screenWidth * 0.7f, screenHeight * 0.1f);

        storyOnePanel.position = new Vector3(screenWidth / 2, ((screenHeight / 2) + screenHeight * 0.2f));
        storyTwoPanel.position = new Vector3(screenWidth / 2, ((screenHeight / 2) - screenHeight * 0.2f));

        mainPanel.GetComponent<Image>().color = GetComponentInParent<AppStyling>().BackgroundColour;

        storyOnePanel.GetComponent<Image>().color = GetComponentInParent<AppStyling>().CardColour;
        storyTwoPanel.GetComponent<Image>().color = GetComponentInParent<AppStyling>().CardColour;

        storyOneButton.GetComponent<Image>().color = GetComponentInParent<AppStyling>().ButtonColour;
        storyTwoButton.GetComponent<Image>().color = GetComponentInParent<AppStyling>().ButtonColour;
    }

    public void LoadStoryOne()
    {
        GameObject.Find("Data").GetComponent<DataHolder>().chosenArc = "SF";
        SceneManager.LoadScene(1);
    }

    public void LoadStoryTwo()
    {
        GameObject.Find("Data").GetComponent<DataHolder>().chosenArc = "TS";
        SceneManager.LoadScene(1);
    }
}
