namespace AfyaApp.Features.MedicalRecords.GetById;

public class GetMedicalRecordByIdRequest
{
    public const string Route = "/medical-record/{Id}";
    public Guid Id { get; init; }
}