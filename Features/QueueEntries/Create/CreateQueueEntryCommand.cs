using FastEndpoints;

namespace AfyaApp.Features.QueueEntries.Create;

public sealed record CreateQueueEntryCommand(
    Guid PatientId,
    string AssignedDoctorId) : ICommand<QueueEntryResponse>;