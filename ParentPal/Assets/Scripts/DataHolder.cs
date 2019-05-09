using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public List<Option> chosenOptions { set; get; }
    public string chosenArc { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        chosenOptions = new List<Option>();
    }
}
