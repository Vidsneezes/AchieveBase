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

    private T _shallowValue;
    public T shallowValue
    {
        get
        {
            return _shallowValue;
        }
    }
    public Action onValueChange;

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


public enum ExTypes
{
    Float,
    Int,
    Bool
}