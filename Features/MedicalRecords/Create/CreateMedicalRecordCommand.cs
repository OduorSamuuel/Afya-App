using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.Create;

public sealed record CreateMedicalRecordCommand(
    Guid PatientId,
    string DoctorId,
    DateTime VisitDate,
    string Diagnosis,
    string Prescription,
    string Notes) : ICommand<MedicalRecordResponse>;