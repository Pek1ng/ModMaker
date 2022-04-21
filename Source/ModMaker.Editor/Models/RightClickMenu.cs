using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModMaker.Editor.Models
{
    public class RightClickMenu
    {
        private IList<RightClickMenu> _items;

        public DelegateCommand<object>? Action { get; set; }

        public string? Header { get; set; }

        public RightClickMenu()
        {
            _items = new List<RightClickMenu>();
        }

        public IList<RightClickMenu> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Visibility Visibility { get; set; }
    }
}