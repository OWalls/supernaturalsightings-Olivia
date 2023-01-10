// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Models;

namespace supernaturalsightings_olivia.Data
{
    public class ReviewDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewCategory> Categories { get; set; }

        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
            : base(options) { }
    }
}
