using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AchievementEditor : EditorWindow {

    [MenuItem("AchieveBase/Achievement Editor")]
    public static void Init()
    {
        AchievementEditor ae = (AchievementEditor)EditorWindow.GetWindow(typeof(AchievementEditor));
        ae.Show();
    }

    void OnGUI()
    {

    }
}

public struct TaskBaseStruct
{
    public string title;
    public string description;
    public string keyToCheck;
    public Comparors comparer;
    public ExTypes variableTypeCheck;
    public bool checkValueBool;
    public float checkValueFloat;
    public int checkValueInt;

}
