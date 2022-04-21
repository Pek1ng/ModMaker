using ModMaker.Sdk;

namespace ProjectZomboid
{
    public class DefaultBuilder : IBuilder
    {
        public DefaultBuilder()
        {
            Game = "ProjectZomboid";

            PluginInfo = new PluginInfo(
                "ModMaker",
                "ProjectZomboid默认构建器",
                "0.01",
                "DefaultBuilder",
                "baidu.com");
        }

        public string Game { get; set; }

        public PluginInfo PluginInfo { get; set; }

        public void OnBuild()
        {
            throw new NotImplementedException();
        }

        public void OnInitialization(string projectPath)
        {
            var pz = new WorkShopProject("test", @$"{projectPath}\src");
            pz.Build();
        }

        public void onLaunch()
        {
            throw new NotImplementedException();
        }
    }
}