using HandyControl.Controls;
using ModMaker.Common.Helper;
using ModMaker.Common.Models;
using ModMaker.Sdk;
using System.Collections.Generic;
using System.IO;

namespace ModMaker.Common.Helpers
{
    public class ProjectHelper
    {
        /// <summary>
        /// 创建项目
        /// </summary>
        /// <param name="ModTemplatesFilePath">模组模板的路径</param>
        /// <param name="ItemName">选用模板的名字</param>
        /// <param name="ProjectName">创建的项目名</param>
        /// <returns>是否创建成功</returns>
        public static bool CreatProject(string projectName, IBuilder builder)
        {
            string projectPath = @$"Projects\{ projectName}";

            if (Directory.Exists(projectPath))
            {
                MessageBox.Show($"项目已存在\"{projectName}\"");

                return false;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(projectPath);
                dir.Create();

                builder.OnInitialization(projectPath);

                dir = new DirectoryInfo(@$"{projectPath}\.work");
                dir.Create();
                dir.Attributes = FileAttributes.Hidden;

                using (StreamWriter sw = new StreamWriter($@"{dir.FullName}\set"))
                {
                    sw.WriteLine(builder.GetType().FullName);
                    sw.WriteLine(Common.Resources.Setting.EditorVersion);
                }

                return true;
            }
        }

        /// <summary>
        /// 要删除的项目名
        /// </summary>
        /// <param name="ProjectName"></param>
        /// <returns>是否删除成功</returns>
        public static bool DelectProject(string projectName)
        {
            DirectoryInfo info = new DirectoryInfo(@$"Projects\{projectName}");

            if (!info.Exists)
            {
                return false;
            }
            else
            {
                info.Delete(true);
                return true;
            }
        }

        /// <summary>
        /// 获取某个项目
        /// </summary>
        /// <param name="projectName">项目名</param>
        /// <returns></returns>
        public static Project? GetProject(string projectName)
        {
            DirectoryInfo dir = new DirectoryInfo(@$"Projects\{projectName}");

            if (!dir.Exists)
            {
                return null;
            }

            Project project = new Project(projectName, dir);
            project.LastWriteTime = dir.LastWriteTime.ToLongDateString();

            var builders = PluginHelper.GetPlugins<IBuilder>();

            using (StreamReader sr = new StreamReader(dir.FullName + @"\.work\set"))
            {
                string? builderName = sr.ReadLine();

                foreach (var builder in builders)
                {
                    if (builder.GetType().FullName == builderName)
                    {
                        project.Builder = builder;
                    }
                }

                project.SdkVersion = sr.ReadLine();
            }

            return project;
        }

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns>项目列表</returns>
        public static IList<Project> GetProjects()
        {
            DirectoryInfo info = new DirectoryInfo("Projects");

            if (!info.Exists)
            {
                info.Create();
            }

            IList<Project> projects = new List<Project>();

            foreach (var item in info.GetDirectories())
            {
                var project = GetProject(item.Name);
                projects.Add(project!);
            }

            return projects;
        }
    }
}