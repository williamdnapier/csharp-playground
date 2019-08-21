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

        private object mAbacus;
        public object Abacus
        {
            get => mAbacus;
            set => mAbacus = value;
        }
        public object AncientCalculator
        {
            get => mAbacus;
            set => mAbacus = value;
        }
        public MyMath()
        {
            //Empty constructor
        }

        public bool ZeroEqualsOne()
        {
            return 0 == 1;
        }

        public bool ZeroEqualsZero()
        {
            return 0 == 0;
        }

        public object GetStudentsBrain(object brain)
        {
            return brain;
        }

        public object GetTeachersBrain(object brain)
        {
            return brain;
        }
    } 
}
