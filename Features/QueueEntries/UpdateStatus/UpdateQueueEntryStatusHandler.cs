using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.UpdateStatus;

public sealed class UpdateQueueEntryStatusHandler(IRepository<QueueEntry> repository)
    : ICommandHandler<UpdateQueueEntryStatusCommand, QueueEntryResponse?>
{
    public async Task<QueueEntryResponse?> ExecuteAsync(UpdateQueueEntryStatusCommand command, CancellationToken ct)
    {
        var entry = await repository.GetByIdAsync(command.Id, ct);
        if (entry is null) return null;

        entry.UpdateStatus(command.Status);
        await repository.UpdateAsync(entry, ct);

        return new QueueEntryResponse(
            entry.Id, entry.PatientId, entry.AssignedDoctorId, entry.Status, entry.CreatedAt, entry.UpdatedAt);
    }
}