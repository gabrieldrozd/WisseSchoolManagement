using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Infrastructure.Database;

internal sealed class UsersDbContext : IdentityDbContext<User, Role, Guid>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");

        modelBuilder.Entity<User>(b => { b.ToTable("Users"); });
        modelBuilder.Entity<IdentityUserClaim<Guid>>(b => { b.ToTable("UserClaims"); });
        modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
        {
            b.ToTable("UserLogins");
            b.HasKey(x => x.UserId);
        });
        modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
        {
            b.ToTable("UserTokens");
            b.HasKey(x => x.UserId);
        });
        modelBuilder.Entity<Role>(b => { b.ToTable("Roles"); });
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(b => { b.ToTable("RoleClaims"); });
        modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
        {
            b.ToTable("UserRoles");
            b.HasKey(x => new { x.UserId, x.RoleId });
        });

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}