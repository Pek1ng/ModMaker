using ModMaker.Hub.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace ModMaker.Hub.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("Content", typeof(ProjectListView));
        }
    }
}