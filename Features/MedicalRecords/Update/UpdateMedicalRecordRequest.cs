namespace AfyaApp.Features.MedicalRecords.Update;

public class UpdateMedicalRecordRequest
{
    public const string Route = "/medical-record/{Id}";
    public Guid Id { get; init; }
    public DateTime VisitDate { get; init; }
    public string Diagnosis { get; init; } = string.Empty;
    public string Prescription { get; init; } = string.Empty;
    public string Notes { get; init; } = string.Empty;
}