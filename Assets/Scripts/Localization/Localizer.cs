using System.Linq;
using UnityEngine;

public static class Localizer
{
    private static string[] _allowedLanguages = { "ru", "en" };
    private static string _selectedLanguage = "ru";

    public static string SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            if (_allowedLanguages.Contains(value))
            {
                _selectedLanguage = value;
                foreach (SimpleTextTranslator text in GameObject.FindObjectsOfType<SimpleTextTranslator>())
                {
                    text.UpdateText();
                }
            }
        }
    }

    public static string GetStringByKey(string key)
    {
        string result = "???";
        string[] localStrings = ((TextAsset)Resources.Load("locals")).text.Split('\n');
        for (int i = 0; i < localStrings.Length; i++)
        {
            string[] row = localStrings[i].Split(';');
            if (key == row[0])
            {
                result = _selectedLanguage switch
                {
                    "ru" => row[1],
                    "en" => row[2],
                    _ => row[2]
                };
            }
        }
        return result;
    }
}