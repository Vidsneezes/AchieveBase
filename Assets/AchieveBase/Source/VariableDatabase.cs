using System.Collections;
using System.Collections.Generic;

public class VariableDatabase
{

    public Dictionary<string, BaseVariable> variables;

    public VariableDatabase()
    {
        variables = new Dictionary<string, BaseVariable>();
    }

    public void AddNewVariable(string variableName, BaseVariable variable, bool overSave = false)
    {
        if (!variables.ContainsKey(variableName))
        {
            variables.Add(variableName, variable);
        }else
        {
            if (overSave)
            {
                variables[variableName] = null;
                variables[variableName] = variable;
            }
        }
    }

    public void SetVariable(string variableName, BaseVariable variable)
    {
        if (!variables.ContainsKey(variableName))
        {
            variables[variableName] = variable;
        }
    }

    public bool GetVariable(string variableName, out BaseVariable variable)
    {
        if (!variables.ContainsKey(variableName))
        {
            variable = variables[variableName];
            return true;
        }
        variable = null;
        return false;
    }
}
