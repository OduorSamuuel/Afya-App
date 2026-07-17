namespace AfyaApp.Features.MedicalRecords.Delete;

public class DeleteMedicalRecordRequest
{
    public const string Route = "/medical-record/{Id}";
    public Guid Id { get; init; }
}