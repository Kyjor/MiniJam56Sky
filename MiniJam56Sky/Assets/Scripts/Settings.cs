using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class Settings : MonoBehaviour
{
    string path;
    string jsonString;

    [HideInInspector]
    public SettingsData data;

    public static Settings Instance;

    void Awake()
    {
        Instance = this;

        path = Application.streamingAssetsPath + "/settings.json";
        jsonString = File.ReadAllText(path);
        data = JsonUtility.FromJson<SettingsData>(jsonString);
    }

    void Update()
    {
        //Pressing ESC quits interactive
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}

[System.Serializable]
public class SettingsData
{
    public int number;
}