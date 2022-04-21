using Prism.Commands;
using System.IO;
using System.Collections.Generic;
using System.Windows;

namespace ModMaker.Editor.Models
{
    public class FolderRightClickMenu : RightClickMenu
    {
        static FolderRightClickMenu()
        {
            Menu = new List<RightClickMenu>();
            Menu.Add(new RightClickMenu() { Header = "打开所在文件夹", Action = new DelegateCommand<object>(OpenInExploder) });
        }

        public static IList<RightClickMenu> Menu { get; set; }

        private static void OpenInExploder(object obj)
        {
            System.Diagnostics.Process.Start("Explorer.exe", ((FolderNode)obj).Info.FullName);
        }
    }
}