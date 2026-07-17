using AfyaApp.Domain;
using Ardalis.Specification;

namespace AfyaApp.Features.QueueEntries.List;

public sealed class ActiveQueueEntriesSpec : Specification<QueueEntry>
{
    public ActiveQueueEntriesSpec()
    {
        Query.Where(q => q.Status == QueueStatus.Waiting || q.Status == QueueStatus.InProgress)
             .OrderBy(q => q.CreatedAt);
    }
}