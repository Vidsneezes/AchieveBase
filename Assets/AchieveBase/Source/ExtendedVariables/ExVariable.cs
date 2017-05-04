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

[System.Serializable]
public class ExVariable<T>: BaseVariable{

    protected T _value;
    public T value
    {
        get
        {
            return _value;
        }

    }

    protected T _shallowValue;
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

    public string Print()
    {
        return (variableName + " ");
    }

}

[System.Serializable]
public class ExInt : ExVariable<int>
{
    public ExInt(int va)
    {
        _value = va;
        _shallowValue = va;
    }
}

[System.Serializable]
public class ExFloat : ExVariable<float>
{
    public ExFloat(float va)
    {
        _value = va;
        _shallowValue = va;
    }
}

[System.Serializable]
public class ExBool : ExVariable<bool>
{
    public ExBool(bool va)
    {
        _value = va;
        _shallowValue = va;
    }   
}

public enum ExTypes
{
    Float,
    Int,
    Bool
}