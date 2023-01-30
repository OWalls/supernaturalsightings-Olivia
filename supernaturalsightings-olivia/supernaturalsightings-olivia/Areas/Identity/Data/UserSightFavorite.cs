namespace supernaturalsightings_olivia.Areas.Identity.Data
{
    public class UserSightFavorite
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int SightId { get; set; }
    }
}
