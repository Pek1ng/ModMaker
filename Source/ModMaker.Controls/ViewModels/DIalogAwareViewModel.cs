using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace ModMaker.Controls.ViewModels
{
    public class DIalogAwareViewModel : BindableBase, IDialogAware
    {
        private string title = "";

        private IEventAggregator _eventAggregator;

        public DIalogAwareViewModel(IContainerExtension container, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            CancelCommand = new DelegateCommand(Cancel);
            OkCommand = new DelegateCommand(Ok);
        }

        public event Action<IDialogResult>? RequestClose;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand OkCommand { get; set; }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        private void Ok()
        {
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