using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario
{
    public string Title { set; get; }
    public string Text { set; get; }
    public List<Option> Options { set; get; }

    public Scenario()
    {
        Title = "INCOMPLETE";
    }

    public Scenario(string title)
    {
        Title = title;
    }

    public Scenario(string title, string text)
    {
        Title = title;
        Text = text;
    }
}
