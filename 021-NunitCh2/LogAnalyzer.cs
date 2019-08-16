using System;

public class LogAnalyzer
{
    public bool isValidLogFileName(string fileName)
    {
        if(!fileName.EndsWith(".slf", StringComparison.Ordinal))
        {
            return false;
        }
        return true;
    }
}