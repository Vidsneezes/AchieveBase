using System;

public class BaseVariable
{
    public Action onValueChange;
    public string variableName;
    public string uniqueId;


    public void SubscribeAction(Action action)
    {
        onValueChange += action;
    }
}

public class ExVariable<T>: BaseVariable{

    private T _value;
    public T value
    {
        get
        {
            return value;
        }

    }

    private T _shallowValue;
    public T shallowValue
    {
        get
        {
            return _shallowValue;
        }
    }

    /// <summary>
    /// Applies a value, this value is permenant and will inovke the callback
    /// </summary>
    /// <param name="permenantValue"></param>
    public void Apply(T permenantValue)
    {
        _value = permenantValue;
        if(onValueChange != null)
        {

        }
    }

    public void Set(T newValue)
    {
        _shallowValue = newValue;
    }

    public virtual bool IsEqual(T otherValue)
    {
        if (value.Equals(otherValue))
        {
            return true;
        }
        return false;
    }

    public virtual int ValueDifference(T otherValue)
    {
        return 0;
    }

}


public class ExInt : ExVariable<int>
{

}

public class ExFloat : ExVariable<float>
{

}

public class ExBool : ExVariable<bool>
{

}

public enum ExTypes
{
    Float,
    Int,
    Bool
}