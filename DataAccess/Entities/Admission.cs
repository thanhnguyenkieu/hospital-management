namespace HospitalManagement.DataAccess.Entities;

public class Admission
{
    public int PatientId { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public string Diagnosis { get; set; }
    public int AttendingDoctorId { get; set; }

    // Navigation properties
    public Patient Patient { get; set; }
    public Doctor AttendingDoctor { get; set; }
}