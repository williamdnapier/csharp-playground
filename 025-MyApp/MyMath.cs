using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025_MyApp
{
    public class MyMath
    {
        public int Add(int i, int j)
        {
            return i + j;
        }

        private object mObj;
        public object Obj
        {
            get => mObj;
            set => mObj = value;
        }
        public object Obj2
        {
            get => mObj;
            set => mObj = value;
        }
        public MyMath()
        {

        }
    } 
}
