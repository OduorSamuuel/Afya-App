using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.Delete;

public sealed record DeleteQueueEntryCommand(Guid Id) : ICommand<bool>;