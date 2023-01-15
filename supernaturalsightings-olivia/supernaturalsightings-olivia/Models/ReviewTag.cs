namespace supernaturalsightings_olivia.Models
{
    public class ReviewTag
    {
        public int ReviewId { get; set; }
        public string ReviewName { get; set; }

        public int ReviewType { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public ReviewTag()
        {

        }
    }
}
