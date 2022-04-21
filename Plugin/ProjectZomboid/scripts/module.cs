namespace ProjectZomboid.scripts
{
    public class module : IsComponent
    {
        public IList<IsComponent> Items = new List<IsComponent>();

        public module(string name) : base(name)
        {
        }
    }
}