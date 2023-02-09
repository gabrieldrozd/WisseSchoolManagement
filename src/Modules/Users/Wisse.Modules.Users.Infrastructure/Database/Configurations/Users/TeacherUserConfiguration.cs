using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations.Users;

internal class TeacherUserConfiguration : IEntityTypeConfiguration<TeacherUser>
{
    public void Configure(EntityTypeBuilder<TeacherUser> builder)
    {
        builder
            .HasOne(x => x.Teacher)
            .WithOne(x => x.User)
            .HasForeignKey<TeacherUser>(x => x.TeacherExternalId);
    }
}