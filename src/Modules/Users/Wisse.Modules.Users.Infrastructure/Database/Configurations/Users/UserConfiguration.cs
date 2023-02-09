using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Entities.Users;
using Wisse.Modules.Users.Domain.ValueObjects.User;
using Wisse.Modules.Users.Infrastructure.Database.Constants;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.ExternalId);
        builder.HasAlternateKey(x => x.Id);
        builder.HasAlternateKey(x => x.Email);

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        builder.Property(x => x.Role)
            .HasConversion(x => x.Value, x => new Role(x))
            .IsRequired();

        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x))
            .HasMaxLength(UserConstants.EmailMaxLength)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasConversion(x => x.Value, x => new PhoneNumber(x))
            .HasMaxLength(UserConstants.PhoneNumberMaxLength)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new FirstName(x))
            .HasMaxLength(UserConstants.FirstNameMaxLength);

        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new LastName(x))
            .HasMaxLength(UserConstants.LastNameMaxLength);

        builder.Property(x => x.SecurityStamp)
            .IsConcurrencyToken()
            .IsRequired();

        builder.Property(x => x.ConcurrencyStamp)
            .IsConcurrencyToken()
            .IsRequired();

        builder.Property(x => x.Permissions)
            .HasConversion(
                x => string.Join(';', x.Select(y => y.ToString())),
                x => x.Split(';', StringSplitOptions.None).Select(Permission.FromString).ToList());

        builder.Property(x => x.Permissions).Metadata.SetValueComparer(
            new ValueComparer<List<Permission>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, next) => HashCode.Combine(a, next.GetHashCode())),
                c => c.ToList()));

        builder
            .HasDiscriminator<string>("UserType")
            .HasValue<AdminUser>(nameof(AdminUser))
            .HasValue<StudentUser>(nameof(StudentUser))
            .HasValue<TeacherUser>(nameof(TeacherUser));
    }
}