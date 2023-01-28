using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wisse.Modules.Enrollments.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class EnrollmentsModuleInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "enrollments");

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EnrollmentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EnrollmentStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                schema: "enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EducationDetails = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    LanguageLevel = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    EnrollmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicants_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalSchema: "enrollments",
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ZipCodeCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    HouseNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EnrollmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalSchema: "enrollments",
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_EnrollmentId",
                schema: "enrollments",
                table: "Applicants",
                column: "EnrollmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EnrollmentId",
                schema: "enrollments",
                table: "Contacts",
                column: "EnrollmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants",
                schema: "enrollments");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "enrollments");

            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "enrollments");
        }
    }
}
