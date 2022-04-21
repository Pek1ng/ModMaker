namespace ProjectZomboid.scripts
{
    /// <summary>
    /// 格式化类型枚举
    /// </summary>
    internal enum FormatStringEnum
    {
        /// <summary>
        ///输出类似与 key=value
        /// </summary>
        Equal,

        /// <summary>
        /// 输出布尔值的类型
        /// </summary>
        BoolEqual,

        /// <summary>
        /// 输出带冒号格式 key:value
        /// </summary>
        Colon,

        /// <summary>
        /// 关键词
        /// </summary>
        Keywords,
    }
}