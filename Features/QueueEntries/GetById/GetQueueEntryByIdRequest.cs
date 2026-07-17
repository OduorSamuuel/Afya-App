namespace AfyaApp.Features.QueueEntries.GetById;

public class GetQueueEntryByIdRequest
{
    public const string Route = "/queue-entry/{Id}";
    public Guid Id { get; init; }
}