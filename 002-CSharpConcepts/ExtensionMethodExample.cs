namespace answers
{
    public static class ExtensionMethodExample
    {
        public static bool IsCapitalized(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return char.IsUpper(s[0]);
            }
            else
                return false;
        }
    }
}