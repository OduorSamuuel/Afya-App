using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.List;

public sealed record ListMedicalRecordsCommand(Guid PatientId) : ICommand<List<MedicalRecordResponse>>;