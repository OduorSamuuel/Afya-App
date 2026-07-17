using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.Delete;

public sealed record DeleteMedicalRecordCommand(Guid Id) : ICommand<bool>;