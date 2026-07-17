using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.List;

public sealed record ListQueueEntriesCommand : ICommand<List<QueueEntryResponse>>;