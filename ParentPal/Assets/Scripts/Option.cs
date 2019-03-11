using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option 
{
    public string Text { set; get; }
    public Scenario Link { set; get; }

    public Option()
    {
        Text = "INCOMPLETE";
        Link = null;
    }

    public Option(string text)
    {
        Text = text;
        Link = null;
    }

    public Option(string text, Scenario link)
    {
        Text = text;
        Link = link;
    }
}
