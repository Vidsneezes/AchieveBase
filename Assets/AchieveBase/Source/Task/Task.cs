using System;

public class Task<T> : ITask {
    public string Title;
    public string description;
    public TaskCondition<T> taskCondition;
    private IGeneralCondition generalCondition;

    public bool ClearConditionChecked()
    {
        if(taskCondition.exType == ExTypes.Float)
        {
            generalCondition = new FloatCondition();
        }else if(taskCondition.exType == ExTypes.Int) 
        {
            generalCondition = new BoolCondition();
        }else if(taskCondition.exType == ExTypes.Bool)
        {
            generalCondition = new IntCondition();
        }
        //here call variable database and check value against task condition
        return generalCondition.ConditionMet();
    }
}

public class TaskCondition<T>
{
    public string valueToCheck;
    public Comparors compareType;
    public ExVariable<T> expectedValue;
    public ExTypes exType;
}

public interface IGeneralCondition
{
    bool ConditionMet();
}

public class FloatCondition : IGeneralCondition
{
    TaskCondition<float> taskCondition;
    public bool ConditionMet()
    {
        return false;
    }
}

public class BoolCondition : IGeneralCondition
{
    TaskCondition<float> taskCondition;
    public bool ConditionMet()
    {
        return false;
    }
}

public class IntCondition : IGeneralCondition
{
    TaskCondition<float> taskCondition;
    public bool ConditionMet()
    {
        return false;
    }
}


public enum Comparors
{
    equal,
    greaterThan,
    lessThan,
    greaterOrEqualThan,
    lessOrEqualThan
}
