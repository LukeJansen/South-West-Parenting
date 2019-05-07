using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Text titleText, textText;

    private List<Scenario> scenarioList;
    private Scenario tempScenario;
    private Option option1, option2, option3, option4, option5;
    private List<GameObject> buttonList;

    private Scenario currentScenario;

    void Start()
    {
        buttonList = new List<GameObject>();
        scenarioList = new List<Scenario>();

        string[] filePaths = Directory.GetFiles(@"Assets/Files/");

        for (int i = 0; i < filePaths.Length; i++)
        {
            Debug.Log(filePaths[i]);
            if (filePaths[i].Substring(filePaths[i].Length - 4) != "meta")
            {
                StreamReader reader = new StreamReader(filePaths[i]);
                string json = reader.ReadLine();
                scenarioList.Add(Scenario.CreateFromJson(json));
                reader.Close();
            }
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
