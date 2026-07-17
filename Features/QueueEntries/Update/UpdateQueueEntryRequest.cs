using AfyaApp.Domain;

namespace AfyaApp.Features.QueueEntries.Update;

public class UpdateQueueEntryRequest
{
    public const string Route = "/queue-entry/{Id}";
    public Guid Id { get; init; }
    public QueueStatus Status { get; init; }
    public string AssignedDoctorId { get; init; } = string.Empty;
}