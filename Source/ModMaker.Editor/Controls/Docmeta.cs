using System;
using System.IO;
using System.Linq;

namespace ModMaker.Editor.Controls
{
    public class Docmeta
    {
        public Docmeta(string path)
        {
            Parse(path);
        }

        public string? OpenType { get; set; }

        private void Parse(string path)
        {
            using (StringReader sr = new StringReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    var kv = line.Split('=');

                    if (kv.Length == 2)
                    {
                        kv = kv.Select(s => s.Trim()).ToArray();

                        switch (kv[0])
                        {
                            case "OpenType":
                                OpenType = kv[1];
                                break;
                        }
                    }
                }
            }
        }
    }
}