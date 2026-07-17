namespace AfyaApp.Features.QueueEntries.Delete;

public class DeleteQueueEntryRequest
{
    public const string Route = "/queue-entry/{Id}";
    public Guid Id { get; init; }
}