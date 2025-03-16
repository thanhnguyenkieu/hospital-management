// ApplicationDbContext.cs

using HospitalManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Province> ProvinceNames { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Admission> Admissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admission>()
            .HasKey(a => new { a.PatientId, a.AdmissionDate });

        modelBuilder.Entity<Patient>()
            .HasOne(p => p.Province)
            .WithMany()
            .HasForeignKey(p => p.ProvinceId);

        modelBuilder.Entity<Admission>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Admission>()
            .HasOne(a => a.AttendingDoctor)
            .WithMany()
            .HasForeignKey(a => a.AttendingDoctorId);

        // Seed data
        modelBuilder.Entity<Province>().HasData(
            new Province { ProvinceId = "ON", ProvinceName = "Ontario" },
            new Province { ProvinceId = "BC", ProvinceName = "British Columbia" },
            new Province { ProvinceId = "AB", ProvinceName = "Alberta" },
            new Province { ProvinceId = "QC", ProvinceName = "Quebec" },
            new Province { ProvinceId = "MB", ProvinceName = "Manitoba" },
            new Province { ProvinceId = "SK", ProvinceName = "Saskatchewan" },
            new Province { ProvinceId = "NS", ProvinceName = "Nova Scotia" },
            new Province { ProvinceId = "NB", ProvinceName = "New Brunswick" },
            new Province { ProvinceId = "NL", ProvinceName = "Newfoundland and Labrador" },
            new Province { ProvinceId = "PE", ProvinceName = "Prince Edward Island" },
            new Province { ProvinceId = "NT", ProvinceName = "Northwest Territories" },
            new Province { ProvinceId = "YT", ProvinceName = "Yukon" },
            new Province { ProvinceId = "NU", ProvinceName = "Nunavut" }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { DoctorId = 1, FirstName = "John", LastName = "Smith", Specialty = "Cardiology" },
            new Doctor { DoctorId = 2, FirstName = "Emily", LastName = "Johnson", Specialty = "Pediatrics" },
            new Doctor { DoctorId = 3, FirstName = "Michael", LastName = "Brown", Specialty = "Orthopedics" },
            new Doctor { DoctorId = 4, FirstName = "Sarah", LastName = "Davis", Specialty = "Dermatology" },
            new Doctor { DoctorId = 5, FirstName = "David", LastName = "Wilson", Specialty = "Neurology" },
            new Doctor { DoctorId = 6, FirstName = "Laura", LastName = "Martinez", Specialty = "Oncology" },
            new Doctor { DoctorId = 7, FirstName = "James", LastName = "Anderson", Specialty = "Gastroenterology" },
            new Doctor { DoctorId = 8, FirstName = "Emma", LastName = "Taylor", Specialty = "Psychiatry" },
            new Doctor { DoctorId = 9, FirstName = "Daniel", LastName = "Thomas", Specialty = "Endocrinology" },
            new Doctor { DoctorId = 10, FirstName = "Olivia", LastName = "Moore", Specialty = "Rheumatology" }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                PatientId = 1, FirstName = "Alice", LastName = "Johnson", Gender = 'F',
                BirthDate = new DateTime(1990, 5, 15), City = "Toronto", ProvinceId = "ON", Allergies = "Peanuts",
                Height = 165, Weight = 70
            },
            new Patient
            {
                PatientId = 2, FirstName = "Bob", LastName = "Williams", Gender = 'M',
                BirthDate = new DateTime(1985, 11, 22), City = "Vancouver", ProvinceId = "BC", Allergies = null,
                Height = 180, Weight = 85
            },
            new Patient
            {
                PatientId = 3, FirstName = "Charlie", LastName = "Brown", Gender = 'M',
                BirthDate = new DateTime(1978, 3, 10), City = "Calgary", ProvinceId = "AB", Allergies = "Shellfish",
                Height = 175, Weight = 90
            },
            new Patient
            {
                PatientId = 4, FirstName = "Diana", LastName = "Miller", Gender = 'F',
                BirthDate = new DateTime(1995, 7, 30), City = "Montreal", ProvinceId = "QC", Allergies = "Pollen",
                Height = 160, Weight = 60
            },
            new Patient
            {
                PatientId = 5, FirstName = "Ethan", LastName = "Davis", Gender = 'M',
                BirthDate = new DateTime(2000, 1, 5), City = "Winnipeg", ProvinceId = "MB", Allergies = null,
                Height = 170, Weight = 75
            },
            new Patient
            {
                PatientId = 6, FirstName = "Fiona", LastName = "Garcia", Gender = 'F',
                BirthDate = new DateTime(1982, 9, 12), City = "Saskatoon", ProvinceId = "SK", Allergies = "Dust",
                Height = 168, Weight = 68
            },
            new Patient
            {
                PatientId = 7, FirstName = "George", LastName = "Rodriguez", Gender = 'M',
                BirthDate = new DateTime(1992, 12, 25), City = "Halifax", ProvinceId = "NS",
                Allergies = "Penicillin", Height = 182, Weight = 88
            },
            new Patient
            {
                PatientId = 8, FirstName = "Hannah", LastName = "Martinez", Gender = 'F',
                BirthDate = new DateTime(1988, 6, 18), City = "Fredericton", ProvinceId = "NB", Allergies = null,
                Height = 155, Weight = 55
            },
            new Patient
            {
                PatientId = 9, FirstName = "Ian", LastName = "Hernandez", Gender = 'M',
                BirthDate = new DateTime(1975, 4, 20), City = "St. Johns", ProvinceId = "NL", Allergies = "Latex",
                Height = 178, Weight = 82
            },
            new Patient
            {
                PatientId = 10, FirstName = "Jessica", LastName = "Lopez", Gender = 'F',
                BirthDate = new DateTime(1998, 8, 8), City = "Charlottetown", ProvinceId = "PE", Allergies = "Nuts",
                Height = 162, Weight = 65
            },
            new Patient
            {
                PatientId = 11, FirstName = "Kevin", LastName = "Lee", Gender = 'M',
                BirthDate = new DateTime(1993, 2, 14), City = "Edmonton", ProvinceId = "AB", Allergies = "Pollen",
                Height = 172, Weight = 78
            },
            new Patient
            {
                PatientId = 12, FirstName = "Linda", LastName = "Clark", Gender = 'F',
                BirthDate = new DateTime(1987, 7, 19), City = "Victoria", ProvinceId = "BC",
                Allergies = "Shellfish", Height = 160, Weight = 62
            },
            new Patient
            {
                PatientId = 13, FirstName = "Mike", LastName = "Lewis", Gender = 'M',
                BirthDate = new DateTime(1976, 12, 3), City = "Regina", ProvinceId = "SK", Allergies = null,
                Height = 185, Weight = 92
            },
            new Patient
            {
                PatientId = 14, FirstName = "Nancy", LastName = "Walker", Gender = 'F',
                BirthDate = new DateTime(1991, 9, 25), City = "Ottawa", ProvinceId = "ON", Allergies = "Penicillin",
                Height = 158, Weight = 57
            },
            new Patient
            {
                PatientId = 15, FirstName = "Oscar", LastName = "Hall", Gender = 'M',
                BirthDate = new DateTime(1984, 4, 12), City = "Quebec City", ProvinceId = "QC", Allergies = "Dust",
                Height = 177, Weight = 80
            },
            new Patient
            {
                PatientId = 16, FirstName = "Patricia", LastName = "Young", Gender = 'F',
                BirthDate = new DateTime(2002, 6, 30), City = "Winnipeg", ProvinceId = "MB", Allergies = null,
                Height = 163, Weight = 65
            },
            new Patient
            {
                PatientId = 17, FirstName = "Quincy", LastName = "Allen", Gender = 'M',
                BirthDate = new DateTime(1997, 3, 8), City = "Halifax", ProvinceId = "NS", Allergies = "Latex",
                Height = 180, Weight = 85
            },
            new Patient
            {
                PatientId = 18, FirstName = "Rachel", LastName = "King", Gender = 'F',
                BirthDate = new DateTime(1989, 11, 11), City = "Fredericton", ProvinceId = "NB", Allergies = "Nuts",
                Height = 167, Weight = 70
            },
            new Patient
            {
                PatientId = 19, FirstName = "Steve", LastName = "Wright", Gender = 'M',
                BirthDate = new DateTime(1979, 8, 22), City = "St. Johns", ProvinceId = "NL", Allergies = null,
                Height = 175, Weight = 77
            },
            new Patient
            {
                PatientId = 20, FirstName = "Tina", LastName = "Scott", Gender = 'F',
                BirthDate = new DateTime(1994, 5, 17), City = "Charlottetown", ProvinceId = "PE",
                Allergies = "Peanuts", Height = 162, Weight = 60
            }
        );

        modelBuilder.Entity<Admission>().HasData(
            new Admission
            {
                PatientId = 1, AdmissionDate = new DateTime(2023, 1, 10), DischargeDate = new DateTime(2023, 1, 15),
                Diagnosis = "Hypertension", AttendingDoctorId = 1
            },
            new Admission
            {
                PatientId = 2, AdmissionDate = new DateTime(2023, 2, 5), DischargeDate = new DateTime(2023, 2, 10),
                Diagnosis = "Pneumonia", AttendingDoctorId = 2
            },
            new Admission
            {
                PatientId = 3, AdmissionDate = new DateTime(2023, 3, 12), DischargeDate = new DateTime(2023, 3, 18),
                Diagnosis = "Fractured Leg", AttendingDoctorId = 3
            },
            new Admission
            {
                PatientId = 4, AdmissionDate = new DateTime(2023, 4, 20), DischargeDate = new DateTime(2023, 4, 25),
                Diagnosis = "Migraine", AttendingDoctorId = 5
            },
            new Admission
            {
                PatientId = 5, AdmissionDate = new DateTime(2023, 5, 15), DischargeDate = new DateTime(2023, 5, 20),
                Diagnosis = "Appendicitis", AttendingDoctorId = 7
            },
            new Admission
            {
                PatientId = 6, AdmissionDate = new DateTime(2023, 6, 10), DischargeDate = new DateTime(2023, 6, 15),
                Diagnosis = "Asthma", AttendingDoctorId = 2
            },
            new Admission
            {
                PatientId = 7, AdmissionDate = new DateTime(2023, 7, 1), DischargeDate = new DateTime(2023, 7, 7),
                Diagnosis = "Skin Infection", AttendingDoctorId = 4
            },
            new Admission
            {
                PatientId = 8, AdmissionDate = new DateTime(2023, 8, 22), DischargeDate = new DateTime(2023, 8, 28),
                Diagnosis = "Depression", AttendingDoctorId = 8
            },
            new Admission
            {
                PatientId = 9, AdmissionDate = new DateTime(2023, 9, 14), DischargeDate = new DateTime(2023, 9, 20),
                Diagnosis = "Diabetes", AttendingDoctorId = 9
            },
            new Admission
            {
                PatientId = 10, AdmissionDate = new DateTime(2023, 10, 5),
                DischargeDate = new DateTime(2023, 10, 10), Diagnosis = "Allergic Reaction", AttendingDoctorId = 10
            },
            new Admission
            {
                PatientId = 11, AdmissionDate = new DateTime(2023, 1, 20),
                DischargeDate = new DateTime(2023, 1, 25), Diagnosis = "Bronchitis", AttendingDoctorId = 2
            },
            new Admission
            {
                PatientId = 12, AdmissionDate = new DateTime(2023, 2, 15),
                DischargeDate = new DateTime(2023, 2, 20), Diagnosis = "Food Allergy", AttendingDoctorId = 10
            },
            new Admission
            {
                PatientId = 13, AdmissionDate = new DateTime(2023, 3, 22),
                DischargeDate = new DateTime(2023, 3, 28), Diagnosis = "Back Pain", AttendingDoctorId = 3
            },
            new Admission
            {
                PatientId = 14, AdmissionDate = new DateTime(2023, 4, 10),
                DischargeDate = new DateTime(2023, 4, 15), Diagnosis = "Migraine", AttendingDoctorId = 5
            },
            new Admission
            {
                PatientId = 15, AdmissionDate = new DateTime(2023, 5, 5), DischargeDate = new DateTime(2023, 5, 10),
                Diagnosis = "Hypertension", AttendingDoctorId = 1
            },
            new Admission
            {
                PatientId = 16, AdmissionDate = new DateTime(2023, 6, 18),
                DischargeDate = new DateTime(2023, 6, 23), Diagnosis = "Asthma", AttendingDoctorId = 2
            },
            new Admission
            {
                PatientId = 17, AdmissionDate = new DateTime(2023, 7, 12),
                DischargeDate = new DateTime(2023, 7, 18), Diagnosis = "Skin Rash", AttendingDoctorId = 4
            },
            new Admission
            {
                PatientId = 18, AdmissionDate = new DateTime(2023, 8, 5), DischargeDate = new DateTime(2023, 8, 10),
                Diagnosis = "Anxiety", AttendingDoctorId = 8
            },
            new Admission
            {
                PatientId = 19, AdmissionDate = new DateTime(2023, 9, 1), DischargeDate = new DateTime(2023, 9, 7),
                Diagnosis = "Diabetes", AttendingDoctorId = 9
            },
            new Admission
            {
                PatientId = 20, AdmissionDate = new DateTime(2023, 10, 15),
                DischargeDate = new DateTime(2023, 10, 20), Diagnosis = "Allergic Reaction", AttendingDoctorId = 10
            },
            new Admission
            {
                PatientId = 1, AdmissionDate = new DateTime(2023, 11, 1), DischargeDate = new DateTime(2023, 11, 7),
                Diagnosis = "Flu", AttendingDoctorId = 2
            },
            new Admission
            {
                PatientId = 3, AdmissionDate = new DateTime(2023, 12, 10),
                DischargeDate = new DateTime(2023, 12, 15), Diagnosis = "Fractured Arm", AttendingDoctorId = 3
            },
            new Admission
            {
                PatientId = 5, AdmissionDate = new DateTime(2024, 1, 5), DischargeDate = new DateTime(2024, 1, 10),
                Diagnosis = "Stomach Pain", AttendingDoctorId = 7
            }
        );
    }
}