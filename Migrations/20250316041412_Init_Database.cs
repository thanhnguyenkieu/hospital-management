using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class Init_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceNames",
                columns: table => new
                {
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceNames", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_ProvinceNames_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "ProvinceNames",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendingDoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => new { x.PatientId, x.AdmissionDate });
                    table.ForeignKey(
                        name: "FK_Admissions_Doctors_AttendingDoctorId",
                        column: x => x.AttendingDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "FirstName", "LastName", "Specialty" },
                values: new object[,]
                {
                    { 1, "John", "Smith", "Cardiology" },
                    { 2, "Emily", "Johnson", "Pediatrics" },
                    { 3, "Michael", "Brown", "Orthopedics" },
                    { 4, "Sarah", "Davis", "Dermatology" },
                    { 5, "David", "Wilson", "Neurology" },
                    { 6, "Laura", "Martinez", "Oncology" },
                    { 7, "James", "Anderson", "Gastroenterology" },
                    { 8, "Emma", "Taylor", "Psychiatry" },
                    { 9, "Daniel", "Thomas", "Endocrinology" },
                    { 10, "Olivia", "Moore", "Rheumatology" }
                });

            migrationBuilder.InsertData(
                table: "ProvinceNames",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { "AB", "Alberta" },
                    { "BC", "British Columbia" },
                    { "MB", "Manitoba" },
                    { "NB", "New Brunswick" },
                    { "NL", "Newfoundland and Labrador" },
                    { "NS", "Nova Scotia" },
                    { "NT", "Northwest Territories" },
                    { "NU", "Nunavut" },
                    { "ON", "Ontario" },
                    { "PE", "Prince Edward Island" },
                    { "QC", "Quebec" },
                    { "SK", "Saskatchewan" },
                    { "YT", "Yukon" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Allergies", "BirthDate", "City", "FirstName", "Gender", "Height", "LastName", "ProvinceId", "Weight" },
                values: new object[,]
                {
                    { 1, "Peanuts", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toronto", "Alice", "F", 165m, "Johnson", "ON", 70m },
                    { 2, null, new DateTime(1985, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vancouver", "Bob", "M", 180m, "Williams", "BC", 85m },
                    { 3, "Shellfish", new DateTime(1978, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calgary", "Charlie", "M", 175m, "Brown", "AB", 90m },
                    { 4, "Pollen", new DateTime(1995, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montreal", "Diana", "F", 160m, "Miller", "QC", 60m },
                    { 5, null, new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winnipeg", "Ethan", "M", 170m, "Davis", "MB", 75m },
                    { 6, "Dust", new DateTime(1982, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saskatoon", "Fiona", "F", 168m, "Garcia", "SK", 68m },
                    { 7, "Penicillin", new DateTime(1992, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halifax", "George", "M", 182m, "Rodriguez", "NS", 88m },
                    { 8, null, new DateTime(1988, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredericton", "Hannah", "F", 155m, "Martinez", "NB", 55m },
                    { 9, "Latex", new DateTime(1975, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Johns", "Ian", "M", 178m, "Hernandez", "NL", 82m },
                    { 10, "Nuts", new DateTime(1998, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlottetown", "Jessica", "F", 162m, "Lopez", "PE", 65m },
                    { 11, "Pollen", new DateTime(1993, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edmonton", "Kevin", "M", 172m, "Lee", "AB", 78m },
                    { 12, "Shellfish", new DateTime(1987, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victoria", "Linda", "F", 160m, "Clark", "BC", 62m },
                    { 13, null, new DateTime(1976, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regina", "Mike", "M", 185m, "Lewis", "SK", 92m },
                    { 14, "Penicillin", new DateTime(1991, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ottawa", "Nancy", "F", 158m, "Walker", "ON", 57m },
                    { 15, "Dust", new DateTime(1984, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quebec City", "Oscar", "M", 177m, "Hall", "QC", 80m },
                    { 16, null, new DateTime(2002, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winnipeg", "Patricia", "F", 163m, "Young", "MB", 65m },
                    { 17, "Latex", new DateTime(1997, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halifax", "Quincy", "M", 180m, "Allen", "NS", 85m },
                    { 18, "Nuts", new DateTime(1989, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredericton", "Rachel", "F", 167m, "King", "NB", 70m },
                    { 19, null, new DateTime(1979, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Johns", "Steve", "M", 175m, "Wright", "NL", 77m },
                    { 20, "Peanuts", new DateTime(1994, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlottetown", "Tina", "F", 162m, "Scott", "PE", 60m }
                });

            migrationBuilder.InsertData(
                table: "Admissions",
                columns: new[] { "AdmissionDate", "PatientId", "AttendingDoctorId", "Diagnosis", "DischargeDate" },
                values: new object[,]
                {
                    { new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Hypertension", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Flu", new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Pneumonia", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Fractured Leg", new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Fractured Arm", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, "Migraine", new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7, "Appendicitis", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7, "Stomach Pain", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, "Asthma", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, "Skin Infection", new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8, "Depression", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9, "Diabetes", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10, "Allergic Reaction", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2, "Bronchitis", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 10, "Food Allergy", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, "Back Pain", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 5, "Migraine", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, "Hypertension", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 2, "Asthma", new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, "Skin Rash", new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 8, "Anxiety", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 9, "Diabetes", new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 10, "Allergic Reaction", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AttendingDoctorId",
                table: "Admissions",
                column: "AttendingDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProvinceId",
                table: "Patients",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ProvinceNames");
        }
    }
}
