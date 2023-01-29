using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Models;

namespace supernaturalsightings_olivia.Areas.Identity.Data;

public class SightDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Review> Reviews { get; set; }

   
    public SightDbContext(DbContextOptions<SightDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}