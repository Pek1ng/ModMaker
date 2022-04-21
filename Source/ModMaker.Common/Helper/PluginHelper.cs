using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace ModMaker.Common.Helper
{
    public static class PluginHelper
    {
        /// <summary>
        /// 获取特定插件列表
        /// </summary>
        /// <typeparam name="T">插件类型</typeparam>
        /// <returns></returns>
        public static IList<T> GetPlugins<T>()
        {
            var files = Directory.GetFiles(@$"{ Environment.CurrentDirectory}\Plugin", "*.dll");

            var plugins = new List<T>();

            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);

                var types = assembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(T)));

                foreach (var type in types)
                {
                    var t = (T?)Activator.CreateInstance(type);

                    if (t != null)
                        plugins.Add(t!);
                }
            }

            return plugins;
        }
    }
}