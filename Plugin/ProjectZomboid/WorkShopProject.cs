using ModMaker.Sdk.Format;
using System.Text;

namespace ProjectZomboid
{
    public class WorkShopProject
    {
        /// <summary>
        /// 项目路径
        /// </summary>
        private string Path;

        /// <summary>
        /// 项目简介,多行用;分割
        /// </summary>
        public string Description = "";

        public IList<Mod> Items = new List<Mod>();

        /// <summary>
        /// 项目名
        /// </summary>
        public string Name;

        /// <summary>
        /// 项目标签
        /// </summary>
        public string Tags = "";

        /// <summary>
        /// 创意工坊界面标题
        /// </summary>
        public string Title = "Mod Template";

        /// <summary>
        /// 项目版本
        /// </summary>
        public string Version = "1";

        /// <summary>
        /// 创意工坊的可见度
        /// </summary>
        public string Visibility = "public";

        public WorkShopProject(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public void Build()
        {
            Directory.CreateDirectory(Path);

            string file = Path + @"\workshop.txt";
            Ini ini = new Ini();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("version" + Title);

            ini.Add("version", Version);
            ini.Add("title", Title);

            foreach (var str in Description.Split(';'))
            {
                ini.Add("description", str);
            }

            ini.Add("tags", Tags);
            ini.Add("visibility", Visibility);

            ini.Save(file);

            using (FileStream fs = new FileStream(@$"{Path}\preview.png", FileMode.Create))
            {
                fs.Write(Resources.Resource.preview);
            }

            foreach (Mod item in Items)
            {
                item.Build(Path);
            }
        }
    }
}