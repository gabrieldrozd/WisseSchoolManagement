﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wisse.Modules.Enrollments.Infrastructure.Database;

#nullable disable

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Migrations
{
    [DbContext(typeof(EnrollmentsDbContext))]
    partial class EnrollmentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("enrollments")
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wisse.Modules.Enrollments.Domain.Entities.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("EnrollmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EnrollmentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasAlternateKey("ExternalId");

                    b.ToTable("Enrollments", "enrollments");
                });

            modelBuilder.Entity("Wisse.Modules.Enrollments.Domain.Entities.Enrollment", b =>
                {
                    b.OwnsOne("Wisse.Modules.Enrollments.Domain.Entities.Applicant", "Applicant", b1 =>
                        {
                            b1.Property<Guid>("ExternalId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<DateTimeOffset>("BirthDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("EducationDetails")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("character varying(80)");

                            b1.Property<int>("EnrollmentId")
                                .HasColumnType("integer");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("LanguageLevel")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("character varying(80)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("ExternalId");

                            b1.HasIndex("EnrollmentId")
                                .IsUnique();

                            b1.ToTable("Applicants", "enrollments");

                            b1.WithOwner("Enrollment")
                                .HasForeignKey("EnrollmentId");

                            b1.Navigation("Enrollment");
                        });

                    b.OwnsOne("Wisse.Modules.Enrollments.Domain.Entities.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("ExternalId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<int>("EnrollmentId")
                                .HasColumnType("integer");

                            b1.Property<string>("HouseNumber")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)");

                            b1.Property<string>("State")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Street")
                                .HasMaxLength(150)
                                .HasColumnType("character varying(150)");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)");

                            b1.Property<string>("ZipCodeCity")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("ExternalId");

                            b1.HasIndex("EnrollmentId")
                                .IsUnique();

                            b1.ToTable("Contacts", "enrollments");

                            b1.WithOwner("Enrollment")
                                .HasForeignKey("EnrollmentId");

                            b1.Navigation("Enrollment");
                        });

                    b.Navigation("Applicant");

                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
