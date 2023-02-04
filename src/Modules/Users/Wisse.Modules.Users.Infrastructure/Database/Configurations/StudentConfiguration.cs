using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Users.Domain.Entities;
using Wisse.Modules.Users.Domain.ValueObjects.Contact;
using Wisse.Modules.Users.Domain.ValueObjects.Student;
using Wisse.Modules.Users.Infrastructure.Database.Constants;

namespace Wisse.Modules.Users.Infrastructure.Database.Configurations;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => x.ExternalId);

        builder.Property(x => x.BirthDate)
            .HasConversion(
                x => x.Value,
                x => new Date(x))
            .IsRequired();

        builder.Property(x => x.EducationDetails)
            .HasConversion(
                x => x.ToString(),
                x => EducationDetails.FromString(x))
            .HasMaxLength(StudentConstants.EducationDetailsMaxLength)
            .IsRequired();

        builder.Property(x => x.LanguageLevel)
            .HasConversion(
                x => x.Key,
                x => new LanguageLevel(x))
            .HasMaxLength(StudentConstants.LanguageLevelMaxLength)
            .IsRequired();

        #region Contact

        builder.OwnsOne(x => x.Contact, contact =>
        {
            contact.ToTable(ContactConstants.ContactTableName);
            contact.WithOwner(x => x.Student).HasForeignKey(x => x.StudentId);
            contact.HasKey(x => x.Id);
            contact.HasKey(x => x.ExternalId);

            contact.Property(x => x.ZipCode)
                .HasConversion(
                    x => x.Value,
                    x => new ZipCode(x))
                .HasMaxLength(ContactConstants.ZipCodeMaxLength);

            contact.Property(x => x.ZipCodeCity)
                .HasMaxLength(ContactConstants.ZipCodeCityMaxLength);

            contact.Property(x => x.State)
                .HasMaxLength(ContactConstants.StateMaxLength);

            contact.Property(x => x.City)
                .HasMaxLength(ContactConstants.CityMaxLength);

            contact.Property(x => x.Street)
                .HasMaxLength(ContactConstants.StreetMaxLength);

            contact.Property(x => x.HouseNumber)
                .HasMaxLength(ContactConstants.HouseNumberMaxLength);
        });

        #endregion
    }
}