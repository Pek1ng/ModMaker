using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModMaker.Editor.Models
{
    public class FolderNode
    {
        private static List<string> _expandedList = new();
        private bool _isSelected;

        public FolderNode(DirectoryInfo info)
        {
            Info = info;
        }

        public IEnumerable<FileNode> Files
        {
            get
            {
                return Info!.GetFiles().Where(file => !file.Name.EndsWith(".docmeta")).Select(file => new FileNode(file)).ToList();
            }
        }

        public IEnumerable<FolderNode> Folders
        {
            get
            {
                return Info!.GetDirectories().Where(dir => !dir.Name.StartsWith('.')).Select(dir => new FolderNode(dir)).ToList();
            }
        }

        public DirectoryInfo Info { get; set; }

        /// <summary>
        /// 在文件目录是否展开
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                if (_expandedList.Contains(Info.FullName))
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 在文件目录是否被选中
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

                if (value)
                {
                    _expandedList.Add(Info.FullName);
                }
                else
                {
                    _expandedList.Remove(Info.FullName);
                }
            }
        }

        /// <summary>
        /// 所有子节点
        /// </summary>
        public IEnumerable<object> Nodes => Files.Union((IEnumerable<object>)Folders);
    }
}