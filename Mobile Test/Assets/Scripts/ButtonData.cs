using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    public Scenario Link { set; get; }
    public Option Option { set; get; }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        transform.parent.GetComponent<ScenarioController>().ChangeScenario(Link, Option);
    }
}
