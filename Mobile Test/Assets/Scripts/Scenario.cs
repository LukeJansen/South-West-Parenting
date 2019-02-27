using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario
{
    public string Title { set; get; }
    public List<Option> Options { set; get; }

    public Scenario()
    {
        Title = "INCOMPLETE";
    }

    public Scenario(string title)
    {
        Title = title;
    }
}
