using HandyControl.Controls;
using ModMaker.Common.Helper;
using ModMaker.Common.Helpers;
using ModMaker.Sdk;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;

namespace ModMaker.Hub.ViewModels
{
    public class NewProjectViewModel : BindableBase
    {
        private IContainerExtension _container;
        private string _projectName = "MyMod";
        private int _selectedIndex;

        public NewProjectViewModel(IContainerExtension container)
        {
            _container = container;

            Builders = PluginHelper.GetPlugins<IBuilder>();
        }

        /// <summary>
        /// 模组模板列表
        /// </summary>
        public IList<IBuilder> Builders { get; set; }

        public DelegateCommand CreateCommand => new(Create);

        /// <summary>
        /// 要创建的项目名
        /// </summary>
        public string ProjectName
        {
            get { return _projectName; }

            set
            {
                _projectName = value;
                RaisePropertyChanged();
            }
        }

        public IBuilder SelectedBuilder
        {
            get
            {
                return Builders[_selectedIndex];
            }
        }

        /// <summary>
        /// listbox选择项目的序号
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        /// <summary>
        /// 创建项目
        /// </summary>
        private void Create()
        {
            //未选择模板
            if (SelectedIndex == -1)
            {
                MessageBox.Show("请选择模板");
                return;
            }

            string errorMessage = "";

            if (!ProjectHelper.CreatProject(ProjectName, SelectedBuilder, ref errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
        }
    }
}