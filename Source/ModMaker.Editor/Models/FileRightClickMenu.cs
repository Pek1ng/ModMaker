using DryIoc;
using ModMaker.Common.Views;
using ModMaker.Editor.Views;
using Prism.Commands;
using System.Collections.Generic;

namespace ModMaker.Editor.Models
{
    public class FileRightClickMenu : RightClickMenu
    {
        static FileRightClickMenu()
        {
            Menu = new List<RightClickMenu>();
            Menu.Add(new RightClickMenu() { Header = "打开", Action = new DelegateCommand<object>(Open) });
            Menu.Add(new RightClickMenu() { Header = "选择打开方式", Action = new DelegateCommand<object>(ChoseOpenType) });
            Menu.Add(new RightClickMenu() { Header = "打开所在文件夹", Action = new DelegateCommand<object>(OpenInExploder) });
        }

        public static IList<RightClickMenu> Menu { get; set; }

        private static void ChoseOpenType(object obj)
        {
            var window = new ChoseOpenTypeView();
            window.ShowDialog();
        }

        private static void Open(object obj)
        {
            System.Diagnostics.Process.Start("Explorer.exe", ((FileNode)obj).Info.FullName);
        }

        private static void OpenInExploder(object obj)
        {
            System.Diagnostics.Process.Start("Explorer.exe", ((FileNode)obj).Info.DirectoryName!);
        }
    }
}