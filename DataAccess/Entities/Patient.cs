namespace HospitalManagement.DataAccess.Entities;

public class Patient
{
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string City { get; set; }
    public string ProvinceId { get; set; }
    public string? Allergies { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }

    // Navigation property
    public Province Province { get; set; }
}