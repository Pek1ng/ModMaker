using ModMaker.Editor.ViewModels;
using ModMaker.Editor.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System.Collections.Generic;
using ModMaker.Common.Models;
using ModMaker.Common.Helpers;
using System.Windows;
using Prism.Regions;
using ModMaker.Hub.Views;
using Prism.Services.Dialogs;
using ModMaker.Controls;

namespace ModMaker.Hub.ViewModels
{
    public class ProjectListViewModel : BindableBase
    {
        private readonly IContainerExtension _container;
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;

        private IList<Project> _projects = new List<Project>();

        private Visibility _visibility = Visibility.Hidden;

        private int _selectedIndex = -1;

        public Project? SelectedBuilder;

        public ProjectListViewModel(IContainerExtension container, IRegionManager regionManager, IDialogService dialogService)
        {
            _container = container;
            _dialogService = dialogService;
            _regionManager = regionManager;

            Projects = ProjectHelper.GetProjects();
        }

        public DelegateCommand CreateNewProjectCommand => new DelegateCommand(CreateProject);

        public DelegateCommand DeleteProjectCommand => new DelegateCommand(DeleteProject);

        public DelegateCommand OpenProjectCommand => new DelegateCommand(OpenProject);

        /// <summary>
        /// 项目列表
        /// </summary>
        public IList<Project> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                SetProperty(ref _projects, value);
            }
        }

        /// <summary>
        /// 选择的项目
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                if (value > -1)
                {
                    Visibility = Visibility.Visible;
                }
                else
                {
                    Visibility = Visibility.Hidden;
                }

                _selectedIndex = value;
            }
        }

        /// <summary>
        /// 未选择项目时，打开项目,删除项目按钮的可视状态
        /// </summary>
        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                SetProperty(ref _visibility, value);
            }
        }

        /// <summary>
        /// 打开新建项目窗口
        /// </summary>
        private void CreateProject()
        {
            _dialogService.Show(null, null, null, "DialogWindow");

            _regionManager.RegisterViewWithRegion("DialogWindowContent", typeof(NewProjectView));
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        private void DeleteProject()
        {
            if (HandyControl.Controls.MessageBox.Show("删除后不可恢复，确定要删除吗", "删除项目", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.None) == System.Windows.MessageBoxResult.Yes)
            {
                ProjectHelper.DelectProject(Projects[SelectedIndex].Name!);
                Projects = ProjectHelper.GetProjects();
            }
        }

        /// <summary>
        /// 用编辑器打开项目
        /// </summary>
        private void OpenProject()
        {
            string projectName = Projects[SelectedIndex].Name!;

            _container.Register<EditorView>(projectName);

            var view = _container.Resolve<EditorView>(projectName);
            var viewModel = view.DataContext as EditorViewModel;

            viewModel!.Project = ProjectHelper.GetProject(projectName);

            if (viewModel.Project!.SdkVersion != Common.Resources.Setting.EditorVersion)
            {
                HandyControl.Controls.MessageBox.Fatal("项目版本与编辑器版本不同");
                return;
            }

            view.Show();
        }
    }
}