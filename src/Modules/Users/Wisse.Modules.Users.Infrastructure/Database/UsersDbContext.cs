using Microsoft.EntityFrameworkCore;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Infrastructure.Database;

internal sealed class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}