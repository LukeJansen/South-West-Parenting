using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Scenario
{
    public string Title;
    public string Text;
    public List<Option> Options;

    public static Scenario CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Scenario>(jsonString);
    }

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

    public void ToFile()
    {
        Debug.Log("ToFile");
        string json = JsonUtility.ToJson(this);
        string path = "Assets/Files/" + Title + ".txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Close();
    }
}
