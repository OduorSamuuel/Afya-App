using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.Update;

public sealed record UpdateMedicalRecordCommand(
    Guid Id,
    DateTime VisitDate,
    string Diagnosis,
    string Prescription,
    string Notes) : ICommand<MedicalRecordResponse?>;