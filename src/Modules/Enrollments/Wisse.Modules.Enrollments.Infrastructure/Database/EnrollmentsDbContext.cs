using Microsoft.EntityFrameworkCore;
using Wisse.Modules.Enrollments.Domain.Entities;

namespace Wisse.Modules.Enrollments.Infrastructure.Database;

internal class EnrollmentsDbContext : DbContext
{
    public DbSet<Enrollment> Enrollments { get; set; }

    public EnrollmentsDbContext(DbContextOptions<EnrollmentsDbContext> options)
        : base(options)
    {
    }
}
