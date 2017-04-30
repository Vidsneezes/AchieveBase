using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AchievementEditor : EditorWindow {

    public TaskBaseStruct taskBaseStruct;

    [MenuItem("AchieveBase/Achievement Editor")]
    public static void Init()
    {
        AchievementEditor ae = (AchievementEditor)EditorWindow.GetWindow(typeof(AchievementEditor));
        ae.Show();
    }

    void OnGUI()
    {
        TaskRenderer();
    }

    void TaskRenderer()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Title ");
        taskBaseStruct.title = EditorGUILayout.TextField(taskBaseStruct.title);
        EditorGUILayout.LabelField("Description ");
        taskBaseStruct.description = EditorGUILayout.TextArea(taskBaseStruct.description);
        EditorGUILayout.LabelField("Pick a variable Type");
        taskBaseStruct.variableTypeCheck = (ExTypes)EditorGUILayout.EnumPopup(taskBaseStruct.variableTypeCheck);
        EditorGUILayout.LabelField("Check Condition");
        
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
