// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.Controllers;

namespace supernaturalsightings_olivia.Data
{   

    public class SightDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Review> Review { get; set; }
        public DbSet<ReviewCategory> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ReviewTag> ReviewTags { get; set;}

        public SightDbContext(DbContextOptions<SightDbContext> options)
            : base(options) { }

  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder.Entity<ReviewTag>().HasKey(et => new { et.ReviewId, et.ReviewType });


        }
    }
}
