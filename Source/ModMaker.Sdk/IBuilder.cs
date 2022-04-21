namespace ModMaker.Sdk
{
    public interface IBuilder : IPlugin
    {
        /// <summary>
        /// 指定此构建器适用的游戏
        /// </summary>
        string Game { get; set; }

        /// <summary>
        /// 项目每次构建调用
        /// </summary>
        void OnBuild();

        /// <summary>
        /// 项目初始化时，只调用一次
        /// </summary>
        void OnInitialization(string projectPath);

        /// <summary>
        /// 项目每次加载时调用，只有初始完成后才调用
        /// </summary>
        void onLaunch();
    }
}