using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using supernaturalsightings_olivia.Models;
=======
using Microsoft.Extensions.ObjectPool;
>>>>>>> 323340206a6123306e7bc35bf1925ba2f529cd4f

namespace supernaturalsightings_olivia.Areas.Identity.Data;

public class SightDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
<<<<<<< HEAD
    public DbSet<Review> Reviews { get; set; }

  //  public DbSet<WeirdRating> WeirdRatings { get; set; }
   
    public SightDbContext(DbContextOptions<SightDbContext> options)
        : base(options)
    {
    }
=======
    public virtual DbSet<UserSightFavorite> UserSightFavorites { get; set; }

    public SightDbContext(DbContextOptions<SightDbContext> options) : base(options)
    { }
>>>>>>> 323340206a6123306e7bc35bf1925ba2f529cd4f

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

<<<<<<< HEAD
}
=======
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

}
>>>>>>> 323340206a6123306e7bc35bf1925ba2f529cd4f
