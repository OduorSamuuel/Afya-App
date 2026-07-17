using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.List;

public sealed class ListQueueEntriesHandler(IReadRepository<QueueEntry> repository)
    : ICommandHandler<ListQueueEntriesCommand, List<QueueEntryResponse>>
{
    public async Task<List<QueueEntryResponse>> ExecuteAsync(ListQueueEntriesCommand command, CancellationToken ct)
    {
        var entries = await repository.ListAsync(new ActiveQueueEntriesSpec(), ct);

        return entries
            .Select(e => new QueueEntryResponse(
                e.Id, e.PatientId, e.AssignedDoctorId, e.Status, e.CreatedAt, e.UpdatedAt))
            .ToList();
    }
}