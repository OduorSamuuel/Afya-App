using AfyaApp.Domain;
using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.Update;

public sealed record UpdateQueueEntryCommand(
    Guid Id,
    QueueStatus Status,
    string AssignedDoctorId) : ICommand<QueueEntryResponse?>;