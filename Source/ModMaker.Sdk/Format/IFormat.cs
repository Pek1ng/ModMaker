using System.IO;

namespace ModMaker.Sdk.Format
{
    public abstract class IFormat<T>
    {
        /// <summary>
        /// 将实例格式化为字符串
        /// </summary>
        /// <returns></returns>
        public abstract string Format();

        /// <summary>
        /// 将字符串反序列化为实例
        /// </summary>
        /// <param name="data">反序列化的数据</param>
        public abstract T Parse(string data);

        /// <summary>
        /// 从文件读取直接转换为实例
        /// </summary>
        /// <param name="path"></param>
        public T Read(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return Parse(sr.ReadToEnd());
            }
        }

        /// <summary>
        /// 直接将实例格式化为文件
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(Format());
            }
        }
    }
}