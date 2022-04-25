using HandyControl.Controls;
using Prism.Services.Dialogs;
using System;
using System.Windows.Controls;

namespace ModMaker.Controls.Views
{
    /// <summary>
    /// PopBaseView.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindow : Window, IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult? Result { get; set; }
    }
}