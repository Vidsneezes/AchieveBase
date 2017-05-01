using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AchievementEditor : EditorWindow {

    public TaskBaseStruct taskBaseStruct;
    public string comparor;
    public int comparorIndex;

    //TODO added condition checking and auto setup

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
        ConditionRenderer();

    }

    void ConditionRenderer()
    {
        EditorGUILayout.LabelField("Key To Check");
        taskBaseStruct.keyToCheck = EditorGUILayout.TextField(taskBaseStruct.keyToCheck);
        switch (taskBaseStruct.variableTypeCheck)
        {
            case ExTypes.Bool:BoolConditionRenderer(); break;
            case ExTypes.Float: FloatConditionRenderer(); break;
            case ExTypes.Int: IntConditionRenderer(); break;

        }
    }

    void BoolConditionRenderer()
    {
        string[] comparors = new string[]
        {
            "Equal",
            "NotEqual"
        };

        comparorIndex = EditorGUILayout.Popup(comparorIndex, comparors);
        comparor = comparors[comparorIndex];
        switch (comparor)
        {
            case "Equal": taskBaseStruct.comparer = Comparors.equal; break;
            case "NotEqual": taskBaseStruct.comparer = Comparors.notEqual; break;
        }

        taskBaseStruct.checkValueBool = EditorGUILayout.Toggle(taskBaseStruct.checkValueBool);
    }

    void IntConditionRenderer()
    {
        string[] comparors = new string[]
       {
            "Equal",
            "NotEqual",
            "LessThan",
            "GreaterThan",
            "LessOrEqualThan",
            "GreaterOrEqualThan"
       };

        comparorIndex = EditorGUILayout.Popup(comparorIndex, comparors);
        comparor = comparors[comparorIndex];
        switch (comparor)
        {
            case "Equal": taskBaseStruct.comparer = Comparors.equal; break;
            case "NotEqual": taskBaseStruct.comparer = Comparors.notEqual; break;
        }
        taskBaseStruct.checkValueInt = EditorGUILayout.IntField(taskBaseStruct.checkValueInt);
    }

    void FloatConditionRenderer()
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
