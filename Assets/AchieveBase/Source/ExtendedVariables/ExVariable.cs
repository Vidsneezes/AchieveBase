using System;

public class ExVariable<T>{

    private T _value;
    public T value
    {
        get
        {
            return value;
        }

        set
        {
            _value = value; 
            if(onValueChange != null)
            {
                onValueChange();
            }
        }
    }

    public Action onValueChange;

}


public enum ExTypes
{
    Float,
    Int,
    Bool
}