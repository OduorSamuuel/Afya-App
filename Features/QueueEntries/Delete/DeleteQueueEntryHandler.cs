using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.Delete;

public sealed class DeleteQueueEntryHandler(IRepository<QueueEntry> repository)
    : ICommandHandler<DeleteQueueEntryCommand, bool>
{
    public async Task<bool> ExecuteAsync(DeleteQueueEntryCommand command, CancellationToken ct)
    {
        var entry = await repository.GetByIdAsync(command.Id, ct);
        if (entry is null) return false;

        await repository.DeleteAsync(entry, ct);
        return true;
    }
}