namespace Processors.Tags
{
    public readonly record struct Tag
    {
        public Tag(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name {get;}
        public string Description {get;}
    }
}