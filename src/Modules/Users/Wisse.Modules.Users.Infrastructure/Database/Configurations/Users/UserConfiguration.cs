using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.Entities.Users.Base;
using Wisse.Modules.Users.Domain.ValueObjects.User;
using Wisse.Modules.Users.Infrastructure.Database.Constants;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new FirstName(x))
            .HasMaxLength(UserConstants.FirstNameMaxLength);

        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new LastName(x))
            .HasMaxLength(UserConstants.LastNameMaxLength);

        builder
            .HasDiscriminator<string>("UserType")
            .HasValue<AdminUser>(nameof(AdminUser))
            .HasValue<StudentUser>(nameof(StudentUser))
            .HasValue<TeacherUser>(nameof(TeacherUser));
    }
}