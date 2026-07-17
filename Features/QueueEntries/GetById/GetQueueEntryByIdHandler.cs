using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.GetById;

public sealed class GetQueueEntryByIdHandler(IReadRepository<QueueEntry> repository)
    : ICommandHandler<GetQueueEntryByIdCommand, QueueEntryResponse?>
{
    public async Task<QueueEntryResponse?> ExecuteAsync(GetQueueEntryByIdCommand command, CancellationToken ct)
    {
        var entry = await repository.GetByIdAsync(command.Id, ct);

        return entry is null
            ? null
            : new QueueEntryResponse(
                entry.Id, entry.PatientId, entry.AssignedDoctorId, entry.Status, entry.CreatedAt, entry.UpdatedAt);
    }
}