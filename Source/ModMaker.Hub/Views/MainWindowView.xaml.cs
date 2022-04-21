using HandyControl.Controls;
using HandyControl.Tools;

namespace ModMaker.Hub.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            ConfigHelper.Instance.SetWindowDefaultStyle();
        }
    }
}