using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.Update;

public sealed class UpdateQueueEntryHandler(IRepository<QueueEntry> repository)
    : ICommandHandler<UpdateQueueEntryCommand, QueueEntryResponse?>
{
    public async Task<QueueEntryResponse?> ExecuteAsync(UpdateQueueEntryCommand command, CancellationToken ct)
    {
        var entry = await repository.GetByIdAsync(command.Id, ct);
        if (entry is null) return null;

        entry.Reassign(command.AssignedDoctorId);
        entry.UpdateStatus(command.Status);
        await repository.UpdateAsync(entry, ct);

        return new QueueEntryResponse(
            entry.Id, entry.PatientId, entry.AssignedDoctorId, entry.Status, entry.CreatedAt, entry.UpdatedAt);
    }
}