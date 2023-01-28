using Microsoft.EntityFrameworkCore;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Infrastructure.Database;

internal class EnrollmentsDbContext : DbContext
{
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public EnrollmentsDbContext(DbContextOptions<EnrollmentsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("enrollments");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
