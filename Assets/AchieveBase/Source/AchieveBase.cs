using System.Collections;
using System.Collections.Generic;

public static class AchieveBase  {

    private static bool init = false;
    private static VariableDatabase variableDatabase;

    public static void Init()
    {
        init = true;
        variableDatabase = new VariableDatabase();
    }

    public static bool GetVariable(string variableName, out BaseVariable variable)
    {
        if(!init)
        {
            Init();
        }

        if(variableDatabase.GetVariable(variableName,out variable))
        {
            return true;
        }
        return false;
    }

}
