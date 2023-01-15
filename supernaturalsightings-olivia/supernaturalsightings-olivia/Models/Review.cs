namespace supernaturalsightings_olivia.Models
{
    public class Review
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        public int ReviewId { get; set; }
        public ReviewCategory Category { get; set; }
        public int Id { get; set; }
        public Review(string userName, string description)
        {
            UserName = userName;
            Description = description;
            
        }
        public Review()
        {

        }

      public override string ToString()
        {
            return UserName;
        }

        public override bool Equals(object? obj)
        {
            return obj is Review @review &&
                Id == review.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
