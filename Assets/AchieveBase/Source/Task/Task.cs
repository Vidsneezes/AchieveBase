using System;

public class Task<T> : ITask {
    public string uniqueId;
    public string Title;
    public string description;
    public ConditionBuilder<T> conditionBuilder;
    private IGeneralCondition generalCondition;

    public bool ClearConditionChecked()
    {
        if(conditionBuilder.exType == ExTypes.Float)
        {
            generalCondition = new FloatCondition();
        }else if(conditionBuilder.exType == ExTypes.Int) 
        {
            generalCondition = new BoolCondition();
        }else if(conditionBuilder.exType == ExTypes.Bool)
        {
            generalCondition = new IntCondition();
        }
        //here call variable database and check value against task condition
        return generalCondition.ConditionMet();
    }
}

public class ConditionBuilder<T>
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
    ConditionBuilder<float> taskCondition;
    public bool ConditionMet()
    {
        return false;
    }
}

public class BoolCondition : IGeneralCondition
{
    ConditionBuilder<float> taskCondition;
    public bool ConditionMet()
    {
        return false;
    }
}

public class IntCondition : IGeneralCondition
{
    ConditionBuilder<float> taskCondition;
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
