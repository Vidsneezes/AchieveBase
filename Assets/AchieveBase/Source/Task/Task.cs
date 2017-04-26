using System;

public class Task<T> : ITask {
    public string Title;
    public string description;
    public TaskCondition<T> taskCondition;

    public bool ClearConditionChecked()
    {
        //here call variable database and check value against task condition
        return false;
    }
}

public struct TaskCondition<T>
{
    public string valueToCheck;
    public Comparors compareType;
    public T expectedValue;
}

public enum Comparors
{
    equal,
    greaterThan,
    lessThan,
    greaterOrEqualThan,
    lessOrEqualThan
}
