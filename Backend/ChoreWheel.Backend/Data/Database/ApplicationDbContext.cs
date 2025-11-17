using ChoreWheel.Backend.Data.Identity;
using ChoreWheel.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;

namespace ChoreWheel.Backend.Data.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, UserContextProvider userProvider) : IdentityDbContext<IdentityUser>(options)
{
    private readonly UserContextProvider _userProvider = userProvider;

    public DbSet<Chore> Chore { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Chore>()
            .HasQueryFilter(chore => chore.OwnedBy.Id == _userProvider.UserId || _userProvider.IsAdmin || chore.SharedWith.Any(sharee => sharee.Id == _userProvider.UserId));
        builder.Entity<Chore>()
            .Navigation(chore => chore.OwnedBy).AutoInclude();
        builder.Entity<Chore>()
            .Navigation(chore => chore.SharedWith).AutoInclude();
    }

    public override int SaveChanges()
    {
        SetDateTimeColumns();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetDateTimeColumns();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetDateTimeColumns()
    {
        var entitiesCreated = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditedEntity && e.State == EntityState.Added)
            .Select(x => (AuditedEntity)x.Entity);

        var entitiesModified = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditedEntity
                        && e.State == EntityState.Modified)
            .Select(x => (AuditedEntity)x.Entity);

        foreach (var entity in entitiesCreated)
        {
            entity.CreationDateTime = DateTimeOffset.Now;
            entity.LastModificationDateTime = entity.CreationDateTime;
        }

        foreach (var entity in entitiesModified)
        {
            entity.LastModificationDateTime = DateTimeOffset.Now;
        }
    }
}