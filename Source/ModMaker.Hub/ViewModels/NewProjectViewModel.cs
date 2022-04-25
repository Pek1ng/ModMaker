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
    public class NewProjectViewModel : BindableBase, IDialogAware
    {
        private string _projectName = "MyMod";
        private int _selectedIndex;

        public NewProjectViewModel(IContainerExtension container)
        {
            Builders = PluginHelper.GetPlugins<IBuilder>();

            CancelCommand = new DelegateCommand(Cancel);
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        public event Action<IDialogResult>? RequestClose;

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand ConfirmCommand { get; set; }

        /// <summary>
        /// 模组模板列表
        /// </summary>
        public IList<IBuilder> Builders { get; set; }

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

        public string? Title { get; set; }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        private void Confirm()
        {
            //未选择模板
            if (SelectedIndex == -1)
            {
                MessageBox.Show("请选择模板");
                return;
            }

            if (!ProjectHelper.CreatProject(ProjectName, SelectedBuilder))
            {
                return;
            }

            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}