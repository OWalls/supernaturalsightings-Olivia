namespace supernaturalsightings_olivia
{
    public abstract class ReviewField
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Value { get; set; }

        public ReviewField()
        {
            Id = nextId;
            nextId++;
        }

        public ReviewField(string value) : this()
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        
        }

        public override bool Equals(object? obj)
        {
            return obj is ReviewField field &&
                Id == field.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}