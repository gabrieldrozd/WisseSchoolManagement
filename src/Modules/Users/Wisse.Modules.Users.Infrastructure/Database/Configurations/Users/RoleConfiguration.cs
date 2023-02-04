using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Common.Domain.Users;
using Wisse.Modules.Users.Domain.Entities.Users.Base;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations.Users;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = Guid.NewGuid(),
                Name = Roles.AdminRole.Name,
                NormalizedName = Roles.AdminRole.NameNormalized
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = Roles.StudentRole.Name,
                NormalizedName = Roles.StudentRole.NameNormalized
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = Roles.TeacherRole.Name,
                NormalizedName = Roles.TeacherRole.NameNormalized
            });
    }
}