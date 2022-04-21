using System.Collections.Generic;

namespace ModMaker.Plugin
{
    public static class Console
    {
        private static IList<string>? _lines;

        public static IList<string> Lines
        {
            get
            {
                if (_lines == null) _lines = new List<string>();
                return _lines;
            }
        }

        public static void Show()
        {
        }
    }
}