﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public GameObject buttonPrefab, optionPanel;
    public Text titleText, textText, optionText, optionDesc;

    private List<Scenario> scenarioList;
    private List<GameObject> buttonList;

    private Scenario currentScenario;
    private Option currentOption;

    void Start()
    {
        buttonList = new List<GameObject>();
        scenarioList = new List<Scenario>();

        //string[] filePaths = Directory.GetFiles(@"Assets/Files/" + GameObject.Find("Data").GetComponent<DataHolder>().chosenArc);
        object[] filePaths = Resources.LoadAll("Files/" + GameObject.Find("Data").GetComponent<DataHolder>().chosenArc, typeof(TextAsset));

        for (int i = 0; i < filePaths.Length; i++)
        {

            //StreamReader reader = new StreamReader(filePaths[i]);
            //string json = reader.ReadLine();
            TextAsset file = filePaths[i] as TextAsset;
            string json = file.text;
            scenarioList.Add(Scenario.CreateFromJson(json));
        }

        currentScenario = scenarioList[0];

        LoadScenario();
    }

    private void LoadScenario()
    {
        titleText.text = currentScenario.Title;
        textText.text = currentScenario.Text;

        if (buttonList.Count > 0) ClearButtons();

        for (int i = 0; i < currentScenario.Options.Count; i++)
        {
            buttonList.Add(Instantiate(buttonPrefab, transform));
            buttonList[i].GetComponent<ButtonData>().Link = currentScenario.Options[i].Link;
            buttonList[i].GetComponent<ButtonData>().Option = currentScenario.Options[i];
            buttonList[i].transform.GetChild(0).GetComponent<Text>().text = currentScenario.Options[i].Text;
        }

        GetComponent<ResponsiveUI>().SetupButtons(buttonList);
        GetComponent<ResponsiveUI>().ResizeTextBox();
    }

    private void ClearButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            Destroy(buttonList[i]);
        }

        buttonList.Clear();
    }

    public void OpenOption(Option option) 
    {
        currentOption = option;
        optionText.text = option.Text;
        optionDesc.text = option.Description;
        optionPanel.SetActive(true);
    }

    public void AcceptOption()
    {
        optionPanel.SetActive(false);
        ChangeScenario(currentOption.Link, currentOption);
    }

    public void CloseOption()
    {
        optionPanel.SetActive(false);
    }

    public void ChangeScenario(int scenario, Option option)
    {
        if (option.Text == "End Screen")
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            GameObject.Find("Data").GetComponent<DataHolder>().chosenOptions.Add(option);
            currentScenario = scenarioList[option.Link];
            LoadScenario();
        }
    }
}
