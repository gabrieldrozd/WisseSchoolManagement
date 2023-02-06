using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Modules.Users.Domain.Entities.Users;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations.Users;

internal class AdminUserConfiguration : IEntityTypeConfiguration<AdminUser>
{
    public void Configure(EntityTypeBuilder<AdminUser> builder)
    {
    }
}