using System.Collections;
using System.Collections.Generic;

public static class AchieveBase  {

    private static bool init = false;
    private static VariableDatabase<ExFloat> floatDatabase;
    private static VariableDatabase<ExInt> intDatabase;
    private static VariableDatabase<ExBool> boolDatabase;


    public static void Init()
    {
        init = true;
        floatDatabase = new VariableDatabase<ExFloat>();
        intDatabase = new VariableDatabase<ExInt>();
        boolDatabase = new VariableDatabase<ExBool>();
    }

    public static void SetFloat(string variableName, float newValue, bool relative = false)
    {
        ExFloat value;
        if(floatDatabase.GetVariable(variableName,out value))
        {
            if(relative == true)
            {
                value.Set(value.shallowValue + newValue);
            }else
            {
                value.Set(newValue);
            }
            floatDatabase.SetVariable(variableName, value);
        }
    }

    public static bool GetFloat(string variableName, out float value)
    {
        ExFloat valueX;
        if(floatDatabase.GetVariable(variableName,out valueX))
        {
            value = valueX.value;
            return true;
        }
        value = 0;
        return false;
    }

    public static bool SetBool(string variableName, bool newValue)
    {
        ExBool value;
        if (boolDatabase.GetVariable(variableName, out value))
        {
            value.Set(newValue);
            boolDatabase.SetVariable(variableName, value);
            return true;
        }
        return false;
    }

    public static bool GetBool(string variableName, out bool value)
    {
        ExBool valueX;
        if (boolDatabase.GetVariable(variableName, out valueX))
        {
            value = valueX.value;
            return true;
        }
        value = false;
        return false;
    }

    public static void SetInt(string variableName, int newValue, bool relative = false)
    {
        ExInt value;
        if (intDatabase.GetVariable(variableName, out value))
        {
            if (relative == true)
            {
                value.Set(value.shallowValue + newValue);
            }
            else
            {
                value.Set(newValue);
            }
            intDatabase.SetVariable(variableName, value);
        }
    }

    public static bool GetInt(string variableName, out int value)
    {
        ExInt valueX;
        if (intDatabase.GetVariable(variableName, out valueX))
        {
            value = valueX.value;
            return true;
        }
        value = 0;
        return false;
    }

}
