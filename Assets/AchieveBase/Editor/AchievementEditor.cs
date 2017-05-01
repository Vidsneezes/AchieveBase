using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AchievementEditor : EditorWindow {

    public TaskBaseStruct taskBaseStruct;
    public string comparor;
    public int comparorIndex;
    string[] comparorInt = new string[]
    {
            "Equal",
            "NotEqual",
            "LessThan",
            "GreaterThan",
            "LessOrEqualThan",
            "GreaterOrEqualThan"
    };

    string[] comparorBool = new string[]
    {
            "Equal",
            "NotEqual"
    };

    string[] comparorFloat = new string[]
    {
            "LessThan",
            "GreaterThan",
    };
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
        comparorIndex = EditorGUILayout.Popup(comparorIndex, comparorBool);
        comparor = comparorBool[comparorIndex];
        switch (comparor)
        {
            case "Equal": taskBaseStruct.comparer = Comparors.equal; break;
            case "NotEqual": taskBaseStruct.comparer = Comparors.notEqual; break;
        }

        taskBaseStruct.checkValueBool = EditorGUILayout.Toggle(taskBaseStruct.checkValueBool);
    }

    void IntConditionRenderer()
    {
        comparorIndex = EditorGUILayout.Popup(comparorIndex, comparorInt);
        comparor = comparorInt[comparorIndex];
        switch (comparor)
        {
            case "Equal": taskBaseStruct.comparer = Comparors.equal; break;
            case "NotEqual": taskBaseStruct.comparer = Comparors.notEqual; break;
            case "LessThan": taskBaseStruct.comparer = Comparors.lessThan; break;
            case "GreaterThan": taskBaseStruct.comparer = Comparors.greaterThan; break;
            case "LessOrEqualThan": taskBaseStruct.comparer = Comparors.lessOrEqualThan; break;
            case "GreaterOrEqualThan": taskBaseStruct.comparer = Comparors.greaterOrEqualThan; break;
        }
        taskBaseStruct.checkValueInt = EditorGUILayout.IntField(taskBaseStruct.checkValueInt);
    }

    void FloatConditionRenderer()
    {
        comparorIndex = EditorGUILayout.Popup(comparorIndex, comparorFloat);
        comparor = comparorFloat[comparorIndex];
        switch (comparor)
        {
            case "LessThan": taskBaseStruct.comparer = Comparors.lessThan; break;
            case "GreaterThan": taskBaseStruct.comparer = Comparors.greaterThan; break;
        }
        taskBaseStruct.checkValueFloat = EditorGUILayout.FloatField(taskBaseStruct.checkValueFloat);
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
