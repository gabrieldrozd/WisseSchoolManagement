﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wisse.Modules.Users.Infrastructure.Database;

#nullable disable

namespace Wisse.Modules.Users.Infrastructure.Database.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("users")
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("ExternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EducationDetails")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageLevel")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("ExternalId");

                    b.HasAlternateKey("Id");

                    b.ToTable("Students", "users");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("ExternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ExternalId");

                    b.HasAlternateKey("Id");

                    b.ToTable("Teachers", "users");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("ExternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Permissions")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ExternalId");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("Id");

                    b.ToTable("Users", "users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Users.AdminUser", b =>
                {
                    b.HasBaseType("Wisse.Modules.Users.Domain.Entities.Users.User");

                    b.HasDiscriminator().HasValue("AdminUser");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Users.StudentUser", b =>
                {
                    b.HasBaseType("Wisse.Modules.Users.Domain.Entities.Users.User");

                    b.Property<Guid>("StudentExternalId")
                        .HasColumnType("uuid");

                    b.HasIndex("StudentExternalId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("StudentUser");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Users.TeacherUser", b =>
                {
                    b.HasBaseType("Wisse.Modules.Users.Domain.Entities.Users.User");

                    b.Property<Guid>("TeacherExternalId")
                        .HasColumnType("uuid");

                    b.HasIndex("TeacherExternalId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("TeacherUser");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Student", b =>
                {
                    b.OwnsOne("Wisse.Modules.Users.Domain.Entities.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("City")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<Guid>("ExternalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("HouseNumber")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<string>("State")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Street")
                                .HasMaxLength(150)
                                .HasColumnType("character varying(150)");

                            b1.Property<Guid>("StudentExternalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)");

                            b1.Property<string>("ZipCodeCity")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("StudentExternalId")
                                .IsUnique();

                            b1.ToTable("Contacts", "users");

                            b1.WithOwner("Student")
                                .HasForeignKey("StudentExternalId");

                            b1.Navigation("Student");
                        });

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Users.StudentUser", b =>
                {
                    b.HasOne("Wisse.Modules.Users.Domain.Entities.Student", "Student")
                        .WithOne("User")
                        .HasForeignKey("Wisse.Modules.Users.Domain.Entities.Users.StudentUser", "StudentExternalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Users.TeacherUser", b =>
                {
                    b.HasOne("Wisse.Modules.Users.Domain.Entities.Teacher", "Teacher")
                        .WithOne("User")
                        .HasForeignKey("Wisse.Modules.Users.Domain.Entities.Users.TeacherUser", "TeacherExternalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Student", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Wisse.Modules.Users.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
