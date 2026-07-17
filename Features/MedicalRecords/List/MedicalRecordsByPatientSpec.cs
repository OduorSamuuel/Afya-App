using AfyaApp.Domain;
using Ardalis.Specification;

namespace AfyaApp.Features.MedicalRecords.List;

public sealed class MedicalRecordsByPatientSpec : Specification<MedicalRecord>
{
    public MedicalRecordsByPatientSpec(Guid patientId)
    {
        Query.Where(r => r.PatientId == patientId)
             .OrderByDescending(r => r.VisitDate);
    }
}