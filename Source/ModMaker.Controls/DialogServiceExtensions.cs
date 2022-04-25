using Prism.Services.Dialogs;
using System;

namespace ModMaker.Controls
{
    public static class DialogServiceExtensions
    {
        public static void Show(this IDialogService dialogService)
        {
            dialogService.Show(null, null);
        }

        public static void Show(this IDialogService dialogService, IDialogParameters? parameters, Action<IDialogResult>? callBack)
        {
            dialogService.Show("DIalogAwareView", parameters, callBack, "DialogWindow");
        }

        public static void ShowDialog(this IDialogService dialogService)
        {
            dialogService.ShowDialog(null, null);
        }

        public static void ShowDialog(this IDialogService dialogService, IDialogParameters? parameters, Action<IDialogResult>? callBack)
        {
            dialogService.ShowDialog("DIalogAwareView", parameters, callBack, "DialogWindow");
        }
    }
}