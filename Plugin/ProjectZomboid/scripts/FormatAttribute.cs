namespace ProjectZomboid.scripts
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class FormatAttribute : Attribute
    {
        public FormatStringEnum FormatString;

        public FormatAttribute(FormatStringEnum formatString)
        {
            FormatString = formatString;
        }
    }
}