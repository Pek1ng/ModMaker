using Prism.Services.Dialogs;

namespace ModMaker.Controls
{
    public static class DialogServiceExtensions
    {
        public static void Show(this IDialogService dialogService, string name, string windowName)
        {
            dialogService.Show(name, null, null, windowName);
        }

        public static void ShowDialog(this IDialogService dialogService, string name, string windowName)
        {
            dialogService.ShowDialog(name, null, null, windowName);
        }
    }
}