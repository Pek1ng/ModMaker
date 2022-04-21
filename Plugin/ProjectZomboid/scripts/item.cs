namespace ProjectZomboid.scripts
{
    public class Item
    {
        #region 参数

        public string? CanBeEquipped { get; set; }

        public string? Capacity { get; set; }

        public string? DisplayCategory { get; set; }

        public string? DisplayName { get; set; }

        public string? Icon { get; set; }

        public string? ItemWhenDry { get; set; }

        public string? Type { get; set; }

        public double? UseDelta { get; set; }

        public double? Weight { get; set; }

        public bool? Wet { get; set; }

        public bool? WetCooldown { get; set; }

        public string? WorldStaticModel { get; set; }

        #endregion 参数
    }
}