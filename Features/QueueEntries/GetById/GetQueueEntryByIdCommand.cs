using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.GetById;

public sealed record GetQueueEntryByIdCommand(Guid Id) : ICommand<QueueEntryResponse?>;