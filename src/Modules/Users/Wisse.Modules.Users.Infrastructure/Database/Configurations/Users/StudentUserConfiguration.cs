using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations.Users;

internal class StudentUserConfiguration : IEntityTypeConfiguration<StudentUser>
{
    public void Configure(EntityTypeBuilder<StudentUser> builder)
    {
        builder
            .HasOne(x => x.Student)
            .WithOne(x => x.User)
            .HasForeignKey<StudentUser>(x => x.StudentExternalId);
    }
}