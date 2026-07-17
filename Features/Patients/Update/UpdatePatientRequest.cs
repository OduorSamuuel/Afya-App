namespace AfyaApp.Features.Patients.Update;

public class UpdatePatientRequest
{
    public const string Route = "/patient/{Id}";
    public Guid Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
    public string Gender { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
}