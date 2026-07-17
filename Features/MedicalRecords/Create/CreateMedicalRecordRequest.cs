namespace AfyaApp.Features.MedicalRecords.Create;

public class CreateMedicalRecordRequest
{
    public const string Route = "/medical-record";
    public Guid PatientId { get; init; }
    public DateTime VisitDate { get; init; }
    public string Diagnosis { get; init; } = string.Empty;
    public string Prescription { get; init; } = string.Empty;
    public string Notes { get; init; } = string.Empty;
}