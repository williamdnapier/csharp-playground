using System;

public class LogAnalyzer
{
    public bool IsValidLogFileName(string fileName)
    {
        if(!fileName.EndsWith(".slf", StringComparison.InvariantCultureIgnoreCase))
        {
            return false;
        }
        return true;
    }
}