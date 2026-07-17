using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.GetById;

public sealed record GetMedicalRecordByIdCommand(Guid Id) : ICommand<MedicalRecordResponse?>;