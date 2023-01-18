namespace supernaturalsightings_olivia.Models;

public class ReviewCategory
{
    public string Username { get; set; }
    public string ReviewType { get; set; }
    public string Description { get; set; }
    public int ReviewCategoryId { get; set; }
    public List<Review> Reviews { get; set; }
    public ReviewCategory(string reviewType)
    {
        ReviewType = reviewType;
    }
    public ReviewCategory()
    {

    }
}
