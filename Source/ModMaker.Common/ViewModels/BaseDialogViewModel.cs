using ModMaker.Common.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;

namespace ModMaker.Common.ViewModels
{
    public class BaseDialogViewModel : BindableBase
    {
        private IContainerExtension _container;

        public BaseDialogViewModel(IContainerExtension container)
        {
            ClosingCommand = new();
            _container = container;

            if (Command1 != null)
                ClosingCommand.RegisterCommand(Command1);
            if (Command2 != null)
                ClosingCommand.RegisterCommand(Command2);
            ClosingCommand.RegisterCommand(CloseWindowCommand);
        }

        public static DelegateCommand? Command1 { get; set; }

        public static DelegateCommand? Command2 { get; set; }

        public CompositeCommand ClosingCommand { get; set; }

        public DelegateCommand CloseWindowCommand => new DelegateCommand(CloseWindow);

        private void CloseWindow()
        {
            var v = _container.Resolve<BaseDialogView>();

            v.Close();
        }
    }
}