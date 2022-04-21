using System.Text.RegularExpressions;

namespace ModMaker.Sdk
{
    /// <summary>
    /// 插件信息
    /// </summary>
    public class PluginInfo
    {
        /// <summary>
        /// 插件信息
        /// </summary>
        /// <param name="author">插件作者</param>
        /// <param name="description">插件描述</param>
        /// <param name="sdkVersion">支持的sdk版本</param>
        /// <param name="title">插件标题</param>
        /// <param name="url">插件链接</param>
        public PluginInfo(string author, string description, string sdkVersion, string title, string url)
        {
            Author = author;
            Description = description;
            SdkVersion = sdkVersion;
            Title = title;

            if (Regex.IsMatch(url, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$"))
            {
                Url = url;
            }
            else
            {
                Url = "";
            }
        }

        /// <summary>
        /// 插件作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///支持sdk版本
        /// </summary>
        public string SdkVersion { get; set; }

        /// <summary>
        /// 插件的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 插件链接
        /// </summary>
        public string Url { get; set; }
    }
}