using ModMaker.Common.Models;
using ModMaker.Editor.Controls;
using ModMaker.Editor.Models;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ModMaker.Editor.ViewModels
{
    public class EditorViewModel : BindableBase
    {
        private Project? _project;
        private FolderNode? _rootFolder;
        private ObservableCollection<TabItemModel> _tabs;
        private FileWatcher? _watcher;

        public EditorViewModel()
        {
            _tabs = new();
        }

        /// <summary>
        /// 当前项目
        /// </summary>
        public Project? Project
        {
            get
            {
                return _project;
            }
            set
            {
                SetProperty(ref _project, value);

                RootFolder = new FolderNode(value!.Info);
                _watcher = new FileWatcher(RootFolder);
                _watcher.FlushTreeView = new System.Action(() =>
                  {
                      RootFolder = new FolderNode(RootFolder.Info);
                  });
            }
        }

        public FolderNode? RootFolder
        {
            get
            {
                return _rootFolder;
            }
            set
            {
                SetProperty(ref _rootFolder, value);
            }
        }

        public ObservableCollection<TabItemModel> Tabs
        {
            get { return _tabs; }
            set { SetProperty(ref _tabs, value); }
        }
    }
}