using AfyaApp.Domain;

namespace AfyaApp.Features.QueueEntries.UpdateStatus;

public class UpdateQueueEntryStatusRequest
{
    public const string Route = "/queue-entry/{Id}/status";
    public Guid Id { get; init; }
    public QueueStatus Status { get; init; }
}