using System;

public enum TaskState
{
    ACTIVE,
    LOCKED,
    UNLOCKED,
    CLEARED
}

public class Task {
    public string uniqueId;
    public string Title;
    public string description;
    public TaskState state;
    public Comparors comparor;
    public ExTypes exType;

    private float value_float;
    private bool value_bool;
    private int value_int;

    public Task(string _title, string _uniqueId, string _description)
    {
        Title = _title;
        uniqueId = _uniqueId;
        description = _description;
        state = TaskState.LOCKED;
    }

    public void ClearConditionChecked()
    {
        if(exType == ExTypes.Float)
        {
            
        }else if(exType == ExTypes.Int) 
        {

        }else if(exType == ExTypes.Bool)
        {

        }
    }

    public void SubsrcibeToVariable()
    {
        //Call variable database here
        ExBool variableTo = new ExBool(false);//delete this and us a call method
        variableTo.SubscribeAction(ClearConditionChecked);
    }
}

public enum Comparors
{
    equal,
    notEqual,
    greaterThan,
    lessThan,
    greaterOrEqualThan,
    lessOrEqualThan
}
