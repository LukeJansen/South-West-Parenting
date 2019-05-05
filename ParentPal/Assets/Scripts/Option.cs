using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option 
{
    public string Text;
    public int Link;

    public static Option CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Option>(jsonString);
    }

    public Option()
    {
        Text = "INCOMPLETE";
    }

    public Option(string text)
    {
        Text = text;
    }

    public Option(string text, int link)
    {
        Text = text;
        Link = link;
    }
}
