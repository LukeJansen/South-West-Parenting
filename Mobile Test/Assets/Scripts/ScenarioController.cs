using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Text titleText, textText;

    private Scenario scenario1, scenario2, scenario3, scenario4;
    private Option option1, option2, option3, option4, option5;
    private List<GameObject> buttonList;

    private Scenario currentScenario;

    void Start()
    {
        buttonList = new List<GameObject>();

        scenario1 = new Scenario("Scenario 1", "Child is born");
        scenario2 = new Scenario("Scenario 2", "Child says first word");
        scenario3 = new Scenario("Scenario 3", "Child falls over and is hurt");
        scenario4 = new Scenario("Scenario 4", "Child is now a teen");

        option1 = new Option("Go to Scenario 1", scenario1);
        option2 = new Option("Go to Scenario 2", scenario2);
        option3 = new Option("Go to Scenario 3", scenario3);
        option4 = new Option("Go to Scenario 4", scenario4);
        option5 = new Option("End Screen");


        List<Option> tempList = new List<Option>();
        tempList.Add(option2);
        tempList.Add(option3);
        tempList.Add(option4);
        scenario1.Options = tempList;

        tempList = new List<Option>();
        tempList.Add(option1);
        tempList.Add(option3);
        tempList.Add(option4);
        scenario2.Options = tempList;

        tempList = new List<Option>();
        tempList.Add(option1);
        tempList.Add(option2);
        tempList.Add(option4);
        scenario3.Options = tempList;

        tempList = new List<Option>();
        tempList.Add(option5);
        scenario4.Options = tempList;

        currentScenario = scenario1;

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
    }

    private void ClearButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            Destroy(buttonList[i]);
        }

        buttonList.Clear();
    }

    public void ChangeScenario(Scenario scenario, Option option)
    {
        if (option.Text == "End Screen")
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            GameObject.Find("Data").GetComponent<DataHolder>().chosenOptions.Add(option);
            currentScenario = scenario;
            LoadScenario();
        }
    }
}
