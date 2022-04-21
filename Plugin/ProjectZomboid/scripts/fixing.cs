namespace ProjectZomboid.scripts
{
    public class fixing : IsComponent
    {
        /// <summary>
        /// 修复的材料
        /// </summary>
        [Format(FormatStringEnum.Colon)]
        public IList<string> Fixer = new List<string>();

        /// <summary>
        /// 待修复的物品
        /// </summary>
        [Format(FormatStringEnum.Colon)]
        public string? Require;

        public fixing(string name) : base(name)
        {
        }
    }
}