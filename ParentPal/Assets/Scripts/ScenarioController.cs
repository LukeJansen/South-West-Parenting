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

        //tempScenario = new Scenario("Scenario 1", "Teen sat playing games console in messy bedroom. Carer knocks on the door and walks in..." +
        //    "\n\n1) Carer flies off the handle... We’ve got to go out soon – get off that blasted computer! and look at the state of this room!When is the last time you cleaned it ? " +
        //    "\n\n2) Carer remains calm: Insert teen name, we’re leaving in half an hour.Can you finish playing your game, get changed and be ready in the kitchen by 7 o’clock.I will give you a reminder in 15 minutes.If you are still on the console, I will turn it off. " +
        //    "\n\n3) Carer shouts upstairs to teen, “We need to go out soon.” Teen shouts back, “ok.” Without diverting their attention from the game." +
        //    "\n\n4) Carer quietly enters teen’s room and requests they come off the computer game to go out later.Teen isn’t really listening");

        //scenarioList.Add(tempScenario);

        //tempScenario = new Scenario("Scenario 2", "Child says first word");
        //scenarioList.Add(tempScenario);

        //option1 = new Option("Carer flies off the handle", 1);
        //option2 = new Option("Carer remains calm", 1);
        //option3 = new Option("Carer shouts upstairs", 1);
        //option4 = new Option("Carer quietly enters room", 1);

        //List<Option> tempList = new List<Option>();

        //tempList.Add(option1);
        //tempList.Add(option2);
        //tempList.Add(option3);
        //tempList.Add(option4);

        //scenarioList[0].Options = tempList;

        //tempList = new List<Option>();

        //option1 = new Option("End Screen");

        //tempList.Add(option1);

        //scenarioList[1].Options = tempList;

        //scenarioList[1].ToFile();

        string[] filePaths = Directory.GetFiles(@"Assets/Files/");

        for (int i = 0; i < filePaths.Length; i++)
        {
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
