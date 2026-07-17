namespace AfyaApp.Features.MedicalRecords
{
   public sealed record MedicalRecordResponse(
    Guid Id,
    Guid PatientId,
    string DoctorId,
    DateTime VisitDate,
    string Diagnosis,
    string Prescription,
    string Notes);
}
