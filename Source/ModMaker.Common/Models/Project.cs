using ModMaker.Sdk;
using System.IO;

namespace ModMaker.Common.Models
{
    public class Project
    {
        public Project(string name, DirectoryInfo info)
        {
            Info = info;
            Name = name;
        }

        /// <summary>
        /// 项目构建器
        /// </summary>
        public IBuilder? Builder { get; set; }

        public DirectoryInfo Info { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public string? LastWriteTime { get; set; }

        /// <summary>
        /// 项目名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编辑器版本
        /// </summary>
        public string? SdkVersion { get; set; }
    }
}