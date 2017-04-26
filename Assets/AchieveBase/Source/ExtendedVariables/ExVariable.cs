using System;

public class ExVariable<T>{

    private T _value;
    public T value
    {
        get
        {
            return value;
        }

    }

    public Action onValueChange;

    private T _shallowValue;
    public T shallowValue
    {
        get
        {
            return _shallowValue;
        }
    }

    public void Apply(T permenantValue)
    {
        _value = permenantValue;
    }

    public void Set(T newValue)
    {
        _shallowValue = newValue;
    }

}


public enum ExTypes
{
    Float,
    Int,
    Bool
}