namespace AfyaApp.Features.MedicalRecords.List;

public class ListMedicalRecordsRequest
{
    public const string Route = "/patient/{PatientId}/medical-records";
    public Guid PatientId { get; init; }
}