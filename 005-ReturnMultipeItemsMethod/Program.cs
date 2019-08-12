using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnMultipeItemsMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            //In many cases, a single return value for a method is not enough.
            //You need a way to return more than one item from a method.

            //Method 1: Use OUT parameters.
            int height;
            int width;
            int depth;
            ReturnDimensions(1, out height, out width, out depth);

            //Method 2: Return a class or struct containing all the return values.
            Dimensions objDim = ReturnDimensions(1);

            //Method 3: Call method returns a tuple with height, width and depth.
            Tuple<int, int, int> objDim2 = ReturnDimensionsAsTuple(1);
        }

        static void ReturnDimensions(int inputShape, out int height, out int width, out int depth)
        {
            height = 0;
            width = 0;
            depth = 0;
        }
   
        static Dimensions ReturnDimensions(int inputShape)
        {
            //The default ctor automatically defaults this structure's members to 0.
            Dimensions objDim = new Dimensions();

            //Calculate objDim.Height, objDim.Width, objDim.Depth from the inputShape value.

            return objDim;
        }

        static Tuple<int, int, int> ReturnDimensionsAsTuple(int inputShape)
        {
            //Calculate objDim.Height, objDim.Width, objDim.Depth from the inputShape.
            //value e.g. { 5, 10, 15 }

            //Create a Tuple with calculated values.
            var objDim = Tuple.Create<int, int, int>(5, 10, 15);

            return (objDim);
        }
    }
    public struct Dimensions
    {
        public int Height;
        public int Width;
        public int Depth;
    }


}
