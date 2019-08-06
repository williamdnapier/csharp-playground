using System;

namespace answers
{
    public struct StructExample
    {
        private int x, y;

        public StructExample(int coord1, int coord2)
        {
            x = coord1;
            y = coord2;
        }

        public void Write()
        {
            Console.WriteLine("StructExample: x coordinate is {0}, y coordinate is {1}", x, y);
        }
    }
}