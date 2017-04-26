using System;

public class Task {
    public string Title;
    public string description;
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
