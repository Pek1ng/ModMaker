using ModMaker.Sdk.Format;
using ProjectZomboid.scripts;
using System.Text;

namespace ProjectZomboid
{
    public class Mod
    {
        /// <summary>
        /// 模组的路径
        /// </summary>
        private string? Path;

        public string Description = "";

        public string Id;

        public IList<module> Items = new List<module>();

        /// <summary>
        /// 模组的名字
        /// </summary>
        public string Name;

        public string Poster = "poster.png";

        public Mod(string name)
        {
            Name = name;
            Id = name.Replace(' ', '_');
        }

        /// <summary>
        /// 构建scripts文件下内容
        /// </summary>
        private void BuildScripts()
        {
            foreach (var item in Items)
            {
                StringBuilder content = new StringBuilder();
                content.Append("module ");
                content.Append(item.Name);
                content.AppendLine("{");
                content.AppendLine(item.ToString());
                content.AppendLine("}");
                string writePath = @$"{Path}\media\scripts";

                if (!Directory.Exists(writePath))
                {
                    Directory.CreateDirectory(writePath);
                }

                using (StreamWriter sw = new StreamWriter(@$"{writePath}\{item.Name}.txt"))
                {
                    sw.Write(content.ToString());
                }
            }
        }

        public void Build(string path)
        {
            Path = path + @$"\Contents\mods\{Name}";
            Directory.CreateDirectory(Path);

            string file = Path + @"\mod.info";

            Ini ini = new Ini();

            ini.Add("name", Name);
            ini.Add("id", Id);

            foreach (var str in Description.Split(';'))
            {
                ini.Add("description", str);
            }

            ini.Add("poster", Poster);

            ini.Save(file);

            using (FileStream fs = new FileStream(@$"{Path}\Poster.png", FileMode.Create))
            {
                fs.Write(Resources.Resource.preview);
            }

            BuildScripts();
        }
    }
}