using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Models;


namespace supernaturalsightings_olivia.Areas.Identity.Data;

public class SightDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{



    public DbSet<Review> Review { get; set; }
    public DbSet<ReviewCategory> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ReviewTag> ReviewTags { get; set; }

 //   public class SightDbContext : DbContext


        public SightDbContext(DbContextOptions<SightDbContext> options)
            : base(options)
        {
        }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        _ = modelBuilder.Entity<ReviewTag>().HasKey(et => new { et.ReviewId, et.ReviewType });
    
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
