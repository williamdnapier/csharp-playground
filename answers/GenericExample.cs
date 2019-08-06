using System;

public class GenericExample<T>
{
    public T prop1 { get; set; }

    public void Add(T input)
    {
        prop1 = input;
    }
}