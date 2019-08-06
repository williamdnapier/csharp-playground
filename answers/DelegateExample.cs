using System;

namespace answers
{
    //Delegate caller method definition.
    delegate int DelegateExample(int x);

    public static class DelegateExampleClass
    {
        //Delegate target (implementation) method.
        public static int Square(int x) => x * x;
    }
}