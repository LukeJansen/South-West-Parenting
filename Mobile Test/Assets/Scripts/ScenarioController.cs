using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Text titleText;

    private Scenario scenario1, scenario2, scenario3, scenario4;
    private Option option1, option2, option3, option4;

    private Scenario currentScenario;

    void Start()
    {
        scenario1 = new Scenario("Scenario 1");
        scenario2 = new Scenario("Scenario 2");
        scenario3 = new Scenario("Scenario 3");
        scenario4 = new Scenario("Scenario 4");

        option1 = new Option("Go to Scenario 1", scenario1);
        option2 = new Option("Go to Scenario 2", scenario2);
        option3 = new Option("Go to Scenario 3", scenario3);
        option4 = new Option("Go to Scenario 4", scenario4);


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
        tempList.Add(option1);
        tempList.Add(option2);
        tempList.Add(option3);
        scenario4.Options = tempList;

        currentScenario = scenario2;

        LoadScenario();
    }

    private void LoadScenario()
    {
        titleText.text = currentScenario.Title;

        List<GameObject> buttonList = new List<GameObject>();

        for (int i = 0; i < currentScenario.Options.Count; i++)
        {
            buttonList.Add(Instantiate(buttonPrefab, transform));
            buttonList[i].GetComponent<ButtonData>().Link = currentScenario.Options[i].Link;
            buttonList[i].transform.GetChild(0).GetComponent<Text>().text = currentScenario.Options[i].Text;
        }

        GetComponent<ResponsiveUI>().SetupButtons(buttonList);
    }

    public void ChangeScenario(Scenario scenario)
    {
        currentScenario = scenario;
        LoadScenario();
    }

}
