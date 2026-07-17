using AfyaApp.Domain;

namespace AfyaApp.Features.QueueEntries;

public sealed record QueueEntryResponse(
    Guid Id,
    Guid PatientId,
    string AssignedDoctorId,
    QueueStatus Status,
    DateTime CreatedAt,
    DateTime UpdatedAt);