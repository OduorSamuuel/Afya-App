using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.Create;

public sealed class CreateQueueEntryHandler(IRepository<QueueEntry> repository)
    : ICommandHandler<CreateQueueEntryCommand, QueueEntryResponse>
{
    public async Task<QueueEntryResponse> ExecuteAsync(CreateQueueEntryCommand command, CancellationToken ct)
    {
        var entry = new QueueEntry(command.PatientId, command.AssignedDoctorId);
        entry = await repository.AddAsync(entry, ct);

        return new QueueEntryResponse(
            entry.Id, entry.PatientId, entry.AssignedDoctorId, entry.Status, entry.CreatedAt, entry.UpdatedAt);
    }
}