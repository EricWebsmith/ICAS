namespace Icas.Common
{
    public class NameAlias
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
