using ChoreWheel.Backend.Data.Identity;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace ChoreWheel.Backend.Data.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, UserContextProvider userProvider) : IdentityDbContext<IdentityUser>(options)
    {
        private readonly UserContextProvider _userProvider = userProvider;

        public DbSet<Chore> Chore { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Chore>()
                .HasQueryFilter(chore => chore.OwnedBy.Id == _userProvider.UserId || _userProvider.IsAdmin || chore.SharedWith.Any(sharee => sharee.Id == _userProvider.UserId))
            builder.Entity<Chore>()
                .Navigation(chore => chore.OwnedBy).AutoInclude();
            builder.Entity<Chore>()
                .Navigation(chore => chore.SharedWith).AutoInclude();

        }
    }
}