namespace AfyaApp.Features.Patients.Delete;

public class DeletePatientRequest
{
    public const string Route = "/patient/{Id}";
    public Guid Id { get; init; }
}