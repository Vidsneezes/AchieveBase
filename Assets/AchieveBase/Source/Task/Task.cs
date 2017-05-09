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
    public string variableToCompare;
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
            float currentValue;
            if(AchieveBase.GetFloat(variableToCompare,out currentValue))
            {
                switch (comparor)
                {
                    case Comparors.greaterThan:
                            if(currentValue > value_float)
                        {
                            //Call Task base to handle on completed
                            //Remove Task
                        }
                        break;
                    case Comparors.lessThan:
                        if(currentValue < value_float)
                        {

                        }
                        break;
                }
            }
        }else if(exType == ExTypes.Int) 
        {
            int currentValue;
            if (AchieveBase.GetInt(variableToCompare, out currentValue))
            {
                switch (comparor)
                {
                    case Comparors.notEqual:
                        if (currentValue != value_int)
                        {
                            //Call Task base to handle on completed
                            //Remove Task
                        }
                        break;
                    case Comparors.equal:
                        if (currentValue == value_int)
                        {
                            //Call Task base to handle on completed
                            //Remove Task
                        }
                        break;
                    case Comparors.lessThan:
                        if (currentValue < value_int)
                        {

                        }
                        break;
                    case Comparors.greaterThan:
                        if (currentValue > value_int)
                        {
                            //Call Task base to handle on completed
                            //Remove Task
                        }
                        break;
                    case Comparors.greaterOrEqualThan:
                        if (currentValue >= value_int)
                        {
                            //Call Task base to handle on completed
                            //Remove Task
                        }
                        break;
                    case Comparors.lessOrEqualThan:
                        if (currentValue <= value_int)
                        {

                        }
                        break;
                }
            }
        }
        else if(exType == ExTypes.Bool)
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
