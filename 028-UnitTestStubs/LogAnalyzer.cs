using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestStubs
{
    class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            //if (!fileName.EndsWith(".slf", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    return false;
            //}
            return true;

            //Our LogAnalyzer class application can be configured to handle multiple
            //log filename extensions using a special adapter for each file. For the
            //sake of simplicity, let's assume that the allowed filenames are stored
            //somewhere on disk as a configuration setting for the application.

            //The problem that arises is that the test depends on the filesystem.
            //Then, we are performing an integration test and not a unit test. Integration
            //tests are slower to run, they need configuration, and they test multiple things.

            //This is an example of test-inhibiting design. The code has some dependency
            //on an external resource which might break even though that the code's logic
            //is perfectly valid.


        }
    }
}
