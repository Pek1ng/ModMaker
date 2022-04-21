namespace ProjectZomboid.scripts
{
    public class Recipe
    {
        #region 参数

        private IList<string> _requires { get; set; } = new List<string>();

        public string? AnimNode { get; set; }

        /// <summary>
        /// 可以从地板拿起材料
        /// </summary>
        public bool? CanBeDoneFromFloor { get; set; }

        /// <summary>
        /// 所属模块
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// 制作后销毁的材料
        /// </summary>
        public string? Destroy { get; set; }

        public double? Heat { get; set; }

        /// <summary>
        /// 制作后保留的材料
        /// </summary>
        public string? Keep { get; set; }

        /// <summary>
        /// 需要被学习才能使用
        /// </summary>
        public bool? NeedToBeLearn { get; set; }

        public bool? NoBrokenItems { get; set; }

        public string? OnCanPerform { get; set; }

        /// <summary>
        /// 制作完成时调用的脚本
        /// </summary>
        public string? OnCreate { get; set; }

        /// <summary>
        /// 获得经验调用的lua脚本
        /// </summary>
        public string? OnGiveXP { get; set; }

        public string? Prop1 { get; set; }

        public string? Prop2 { get; set; }

        /// <summary>
        /// 需要的材料
        /// </summary>
        public string? Require
        {
            set
            {
                if (value != null)
                    _requires.Add(value);
            }
        }

        /// <summary>
        /// 获得的材料
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// 技能需求
        /// </summary>
        public string? SkillRequired { get; set; }

        /// <summary>
        /// 播放的音乐
        /// </summary>
        public string? Sound { get; set; }

        /// <summary>
        /// 制作时间
        public double? Time { get; set; }

        public string? Tooltip { get; set; }

        #endregion 参数
    }
}