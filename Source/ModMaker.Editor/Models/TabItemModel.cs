using System.Windows.Controls;
using System.Windows.Media;

namespace ModMaker.Editor.Models
{
    public class TabItemModel
    {
        public object? Control { get; set; }

        public string? Color { get; set; }

        public string? Header { get; set; }
    }
}