using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wisse.Common.Domain.ValueObjects;
using Wisse.Modules.Enrollments.Domain.Entities;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Applicant;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Contact;
using Wisse.Modules.Enrollments.Domain.ValueObjects.Enrollment;
using Wisse.Modules.Enrollments.Infrastructure.Database.Constants;

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Configurations;

internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => x.ExternalId);

        builder.Property(x => x.EnrollmentDate)
            .HasConversion(
                x => x.Value,
                x => new Date(x))
            .IsRequired();

        builder.Property(x => x.EnrollmentStatus)
            .HasConversion(
                x => x.Value,
                x => new EnrollmentStatus(x))
            .HasMaxLength(EnrollmentConstants.EnrollmentStatusMaxLength)
            .IsRequired();

        #region Applicant

        builder.OwnsOne(x => x.Applicant, applicant =>
        {
            applicant.ToTable(ApplicantConstants.ApplicantTableName);
            applicant.WithOwner(x => x.Enrollment).HasForeignKey(x => x.EnrollmentId);
            applicant.HasKey(x => x.Id);
            applicant.HasKey(x => x.ExternalId);

            applicant.Property(x => x.FirstName)
                .HasMaxLength(ApplicantConstants.FirstNameMaxLength)
                .IsRequired();

            applicant.Property(x => x.LastName)
                .HasMaxLength(ApplicantConstants.LastNameMaxLength)
                .IsRequired();

            applicant.Property(x => x.BirthDate)
                .HasConversion(
                    x => x.Value,
                    x => new Date(x))
                .IsRequired();

            applicant.Property(x => x.EducationDetails)
                .HasConversion(
                    x => x.ToString(),
                    x => EducationDetails.FromString(x))
                .HasMaxLength(ApplicantConstants.EducationDetailsMaxLength)
                .IsRequired();

            applicant.Property(x => x.LanguageLevel)
                .HasConversion(
                    x => x.Key,
                    x => new LanguageLevel(x))
                .HasMaxLength(ApplicantConstants.LanguageLevelMaxLength)
                .IsRequired();
        });

        #endregion

        #region Contact

        builder.OwnsOne(x => x.Contact, contact =>
        {
            contact.ToTable(ContactConstants.ContactTableName);
            contact.WithOwner(x => x.Enrollment).HasForeignKey(x => x.EnrollmentId);
            contact.HasKey(x => x.Id);
            contact.HasKey(x => x.ExternalId);

            contact.Property(x => x.Email)
                .HasConversion(
                    x => x.Value,
                    x => new Email(x))
                .HasMaxLength(ContactConstants.EmailMaxLength)
                .IsRequired();

            contact.Property(x => x.Phone)
                .HasConversion(
                    x => x.Value,
                    x => new Phone(x))
                .HasMaxLength(ContactConstants.PhoneMaxLength)
                .IsRequired();

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