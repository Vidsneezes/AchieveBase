using System;

public enum TaskState
{
    ACTIVE,
    LOCKED,
    UNLOCKED,
    CLEARED
}

public class Task<T>  {
    public string uniqueId;
    public string Title;
    public string description;
    public TaskState state;
    public ConditionBuilder<T> conditionBuilder;
    private IGeneralCondition generalCondition;

    public Task(string _title, string _uniqueId, string _description)
    {
        Title = _title;
        uniqueId = _uniqueId;
        description = _description;
        state = TaskState.LOCKED;
        conditionBuilder = new ConditionBuilder<T>();
    }

    public void ClearConditionChecked()
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
        if (generalCondition.ConditionMet())
        {

        }
    }

    public void SubsrcibeToVariable()
    {
        //Call variable database here
        ExVariable<T> variableTo = new ExVariable<T>();//delete this and us a call method
        variableTo.SubscribeAction(ClearConditionChecked);
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
