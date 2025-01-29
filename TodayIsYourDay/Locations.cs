namespace GameProject
{
    public class Location
    {
        public string Name { get; }
        public string Description { get; }
        public int X { get; }
        public int Y { get; }
        public bool Accessible { get; }
        public string Dialogue { get; }

        public Location(string name, string description, int x, int y, bool accessible, string dialogue)
        {
            Name = name;
            Description = description;
            X = x;
            Y = y;
            Accessible = accessible;
            Dialogue = dialogue;
        }
    }
}
