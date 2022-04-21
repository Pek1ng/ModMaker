using ModMaker.Editor.Models;
using System;
using System.IO;

namespace ModMaker.Editor.Controls
{
    public class FileWatcher
    {
        /// <summary>
        /// 文件树
        /// </summary>
        private FolderNode _folder;

        private FileSystemWatcher _watcher;

        /// <summary>
        ///刷新文件树的委托
        /// </summary>
        public Action FlushTreeView;

        public FileWatcher(FolderNode folder)
        {
            _watcher = new FileSystemWatcher();
            FlushTreeView = new Action(() => { });

            _folder = folder;

            _watcher.Path = folder.Info.FullName;

            _watcher.Created += new FileSystemEventHandler(OnCreated);
            _watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            _watcher.Renamed += new RenamedEventHandler(OnRenamed);

            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;

            InitInfo(folder);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(e.FullPath))
            {
                return;
            }

            _watcher.EnableRaisingEvents = false;

            System.IO.File.Create($"{e.FullPath}.docmeta").Close();
            System.IO.File.SetAttributes($"{e.FullPath}.docmeta", FileAttributes.Hidden);

            FlushTreeView();

            _watcher.EnableRaisingEvents = true;
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(e.FullPath))
            {
                return;
            }

            _watcher.EnableRaisingEvents = false;

            System.IO.File.Delete($@"{e.FullPath}.docmeta");

            FlushTreeView();

            _watcher.EnableRaisingEvents = true;
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!File.Exists(e.FullPath))
            {
                return;
            }

            _watcher.EnableRaisingEvents = false;

            System.IO.File.Move($@"{e.OldFullPath}.docmeta", $@"{e.FullPath}.docmeta");

            FlushTreeView();

            _watcher.EnableRaisingEvents = false;
        }

        public static void InitInfo(FolderNode folder)
        {
            foreach (var item in folder.Folders)
            {
                InitInfo(item);
            }

            foreach (var item in folder.Files)
            {
                FileInfo file = new FileInfo($@"{item.Info.FullName}.docmeta");

                if (!file.Exists)
                {
                    file.Create();
                    file.Attributes = FileAttributes.Hidden;
                }
            }
        }
    }
}