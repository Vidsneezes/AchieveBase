using System.Collections;
using System.Collections.Generic;

public class VariableDatabase<T>
{
    public Dictionary<string, T> variables;

    public VariableDatabase()
    {
    }

    public void AddNewVariable(string variableName, T variable, bool overSave = false)
    {
        if (!variables.ContainsKey(variableName))
        {
            variables.Add(variableName, variable);
        }else
        {
            if (overSave)
            {
                variables[variableName] = variable;
            }
        }
    }

    public void SetVariable(string variableName, T variable)
    {
        if (!variables.ContainsKey(variableName))
        {
            variables[variableName] = variable;
        }
    }

    public bool GetVariable(string variableName, out T variable)
    {
        if (!variables.ContainsKey(variableName))
        {
            variable = variables[variableName];
            return true;
        }
        variable = default(T);
        return false;
    }
}

