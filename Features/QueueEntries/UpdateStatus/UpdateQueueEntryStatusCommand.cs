using AfyaApp.Domain;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.UpdateStatus;

public sealed record UpdateQueueEntryStatusCommand(Guid Id, QueueStatus Status) : ICommand<QueueEntryResponse?>;