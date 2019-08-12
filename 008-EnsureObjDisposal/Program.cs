using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_EnsureObjDisposal
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //Problem
    //You require something that always happens when an object's work is done.

    //Solution
    //Use the using statement.
    public class ObjDisposal
    {
        public void Dispose()
        {
            using (FileStream FS = new FileStream("Text.txt", FileMode.Create))
            {
                FS.WriteByte((byte)1);
                FS.WriteByte((byte)2);
                FS.WriteByte((byte)3);

                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("some text");
                }
            };
        }
    }

    //Points to consider about the using statement.
    //01. It is (obviously) not the same as the using directive at the top of the .cs file.

    //02. The variable defined in the using statement clause must all be of the same type and they
    //must have an initializer.

    //03. Any variable defined in the using clauses are considered read-only in the body of the
    //using statement. This prevents a developer from inadvertantly switching the variable to refer
    //to a different object and causing problems when attempting to dispose of the object.

    //04. The variable should NOT be declared outside the using block and then initialized inside
    //the using clause.
}
