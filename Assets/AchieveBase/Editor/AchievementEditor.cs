using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class AchievementEditor : EditorWindow {


    public ExVariableStruct exVraibleStruct;
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

    private bool tempBool;
    private float tempFloat;
    private int tempInt;
    private VariableDataContainer variableDataContiner;
    private VariableContainerStruct variableContainerStruct;
    private SearchStruct searchStruct;
    private bool boolDisplay;
    private bool intDisplay;
    private bool floatDisplay;
    //TODO added condition checking and auto setup

    [MenuItem("AchieveBase/Achievement Editor")]
    public static void Init()
    {
        AchievementEditor ae = (AchievementEditor)EditorWindow.GetWindow(typeof(AchievementEditor));
        ae.Show();
    }

    void OnGUI()
    {
        if(variableDataContiner == null)
        {
            variableDataContiner = AssetDatabase.LoadAssetAtPath<VariableDataContainer>("Assets/__VariableDatabase.asset");
            if (variableDataContiner == null)
            {
                variableDataContiner = (VariableDataContainer)ScriptableObject.CreateInstance(typeof(VariableDataContainer));

                AssetDatabase.CreateAsset(variableDataContiner, "Assets/__VariableDatabase.asset");
                AssetDatabase.SaveAssets();
                variableContainerStruct.bools = new List<ExBool>(variableDataContiner.bools.ToArray() );
                variableContainerStruct.ints = new List<ExInt>(variableDataContiner.ints.ToArray()); 
                variableContainerStruct.floats = new List<ExFloat>(variableDataContiner.floats.ToArray());
            }
            else
            {
                variableContainerStruct.bools = new List<ExBool>(variableDataContiner.bools.ToArray());
                variableContainerStruct.ints = new List<ExInt>(variableDataContiner.ints.ToArray());
                variableContainerStruct.floats = new List<ExFloat>(variableDataContiner.floats.ToArray());
            }

        }
        VariableViewRenderer();
        AddNewVariableRenderer();
        SearchVariableRenderer();
    }

    public void OnInspectorUpdate()
    {
        this.Repaint();
    }

    void SearchVariableRenderer()
    {
        EditorGUILayout.LabelField("Searc For Variable");

        searchStruct.query = EditorGUILayout.TextField(searchStruct.query);
        EditorGUILayout.LabelField("Type of Variable");
        searchStruct.type = (ExTypes)EditorGUILayout.EnumPopup(searchStruct.type);
        FindThisVariable();
    }

    void AddTaskRenderer()
    {
        EditorGUILayout.LabelField("Task Name");
    }

    void FindThisVariable()
    {
        string variable = searchStruct.query;
        ExTypes type = searchStruct.type;
        switch (type)
        {
            case ExTypes.Bool: FindBoolVariable(variable); break;
            case ExTypes.Float:FindFloatVariable(variable); break;
            case ExTypes.Int: FindIntVariable(variable); break;
        }
    }

    void FindFloatVariable(string variable)
    {
        for (int i = 0; i < variableContainerStruct.floats.Count; i++)
        {
            if(variableContainerStruct.floats[i].variableName == variable)
            {
                EditorGUILayout.LabelField(variableContainerStruct.floats[i].Print());
            }
        }
    }

    void FindBoolVariable(string variable)
    {
        for (int i = 0; i < variableContainerStruct.bools.Count; i++)
        {
            EditorGUILayout.LabelField(variableContainerStruct.bools[i].Print());
        }
    }

    void FindIntVariable(string variable)
    {
        for (int i = 0; i < variableContainerStruct.ints.Count; i++)
        {
            EditorGUILayout.LabelField(variableContainerStruct.ints[i].Print());
        }
    }

    void VariableViewRenderer()
    {
        boolDisplay = EditorGUILayout.Foldout(boolDisplay, "Bools");
        if (boolDisplay)
        {
            for (int i = 0; i < variableContainerStruct.bools.Count; i++)
            {
                EditorGUILayout.LabelField(variableContainerStruct.bools[i].Print());
            }
        }

        intDisplay = EditorGUILayout.Foldout(intDisplay, "Ints");
        if (intDisplay)
        {
            for (int i = 0; i < variableContainerStruct.ints.Count; i++)
            {
                EditorGUILayout.LabelField(variableContainerStruct.ints[i].Print());
            }
        }

        floatDisplay = EditorGUILayout.Foldout(floatDisplay, "Floats");
        if (floatDisplay)
        {
            for (int i = 0; i < variableContainerStruct.floats.Count; i++)
            {
                EditorGUILayout.LabelField(variableContainerStruct.floats[i].Print());
            }
        }
    }

    void AddNewVariableRenderer()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Add new Variable");
        EditorGUILayout.LabelField("Variable Type");
        exVraibleStruct.type = (ExTypes)EditorGUILayout.EnumPopup(exVraibleStruct.type);
        EditorGUILayout.LabelField("Variable Name");
        exVraibleStruct.value = EditorGUILayout.TextField(exVraibleStruct.value);
        EditorGUILayout.LabelField("Start Value");
        switch (exVraibleStruct.type)
        {
            case ExTypes.Bool: exVraibleStruct.bool_start = EditorGUILayout.Toggle(exVraibleStruct.bool_start); break;
            case ExTypes.Float: exVraibleStruct.float_start = EditorGUILayout.FloatField(exVraibleStruct.float_start); break;
            case ExTypes.Int: exVraibleStruct.int_start = EditorGUILayout.IntField(exVraibleStruct.int_start); break;
        }

        if(GUILayout.Button("Save Variable"))
        {
            SaveVariable();
            exVraibleStruct.type = ExTypes.Bool;
            exVraibleStruct.value = "";
            exVraibleStruct.bool_start = false;
            exVraibleStruct.int_start = 0;
            exVraibleStruct.float_start = 0;
            this.Repaint();
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(variableDataContiner);
            AssetDatabase.SaveAssets();

        }
    }

    public void SaveVariable()
    {
        switch (exVraibleStruct.type)
        {
            case ExTypes.Bool:
                SaveBool();
                variableDataContiner.bools = variableContainerStruct.bools;
                break;
            case ExTypes.Float:
                SaveFloat();
                variableDataContiner.floats = variableContainerStruct.floats;
                break;
            case ExTypes.Int:
                SaveInt();
                variableDataContiner.ints = variableContainerStruct.ints;
                break;
        }
    }

    private void SaveBool()
    {
        ExBool exBool = new ExBool(exVraibleStruct.bool_start);
        exBool.variableName = exVraibleStruct.value;
        if (!variableContainerStruct.bools.Contains(exBool))
        {
            variableContainerStruct.bools.Add(exBool);
        }
    }

    private void SaveInt()
    {
        ExInt exInt = new ExInt(exVraibleStruct.int_start);
        exInt.variableName = exVraibleStruct.value;
        if (!variableContainerStruct.ints.Contains(exInt))
        {
            variableContainerStruct.ints.Add(exInt);
        }
    }

    private void SaveFloat()
    {
        ExFloat exFloat = new ExFloat(exVraibleStruct.float_start);
        exFloat.variableName = exVraibleStruct.value;
        if (!variableContainerStruct.floats.Contains(exFloat))
        {
            variableContainerStruct.floats.Add(exFloat);
        }
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

        tempBool = EditorGUILayout.Toggle(taskBaseStruct.checkValueBool);
        taskBaseStruct.checkValueBool = tempBool; 
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
        tempInt = EditorGUILayout.IntField(taskBaseStruct.checkValueInt);
        taskBaseStruct.checkValueInt = tempInt;
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
        tempFloat = EditorGUILayout.FloatField(taskBaseStruct.checkValueFloat);
        taskBaseStruct.checkValueFloat = tempFloat;
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

public struct ExVariableStruct
{
    public float float_start;
    public bool bool_start;
    public int int_start;
    public ExTypes type;
    public string value;
}

public struct VariableContainerStruct
{
    public List<ExBool> bools;
    public List<ExInt> ints;
    public List<ExFloat> floats;
}

public struct SearchStruct
{
    public string query;
    public ExTypes type;
}

public struct TaskBuilderStruct
{
    public string taskName;
    public string valueToCheck;
    public ExTypes valueType;
    public float expected_float;
    public bool expected_bool;
    public int expected_int;
    public Comparors compareType;
}