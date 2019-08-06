using System;

namespace answers
{
    interface IInterfaceExample
    {
        int Status { get; set; }
        void Read();
        void Write();
    }

    class InterfaceExample : IInterfaceExample
    {
        public int Status { get; set; }

        public void Read()
        {
            Console.WriteLine("InterfaceExample read method");
        }

        public void Write()
        {
            Console.WriteLine("InterfaceExample write method");
        }
    }
}