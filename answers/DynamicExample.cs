using System;
using System.Dynamic;

public class DynamicExample2 : DynamicObject
{
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        Console.WriteLine("DynamicExample2 parameter binder.Name with value " + binder.Name + " was called");
        result = null;
        return true;
    }
}