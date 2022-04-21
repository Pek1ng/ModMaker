using Prism.Mvvm;
using System.IO;

namespace ModMaker.Editor.Models
{
    public class FileNode
    {
        public FileNode(FileInfo info)
        {
            Info = info;
        }

        public FileInfo Info { get; set; }

        public bool IsExpanded { get; set; }

        public bool IsSelected { get; set; }
    }
}