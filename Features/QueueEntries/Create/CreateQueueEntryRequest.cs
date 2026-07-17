namespace AfyaApp.Features.QueueEntries.Create;

public class CreateQueueEntryRequest
{
    public const string Route = "/queue-entry";
    public Guid PatientId { get; init; }
    public string AssignedDoctorId { get; init; } = string.Empty;
}