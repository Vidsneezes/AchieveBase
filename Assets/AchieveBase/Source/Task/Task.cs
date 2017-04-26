using System;

public class Task {
    public string Title;
    public string description;
}

public struct TaskConditionFloat
{
    public string valueToCheck;
    public Comparors compareType;
    public float expectedValue;
}

public struct TaskConditionBool
{
    public string valueToCheck;
    public Comparors compareType;
    public bool expectedValue;
}

public struct TaskConditionInt
{
    public string valueToCheck;
    public Comparors compareType;
    public int expectedValue;
}

public enum Comparors
{
    equal,
    greaterThan,
    lessThan,
    greaterOrEqualThan,
    lessOrEqualThan
}
