using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.List;

public sealed class ListMedicalRecordsHandler(IReadRepository<MedicalRecord> repository)
    : ICommandHandler<ListMedicalRecordsCommand, List<MedicalRecordResponse>>
{
    public async Task<List<MedicalRecordResponse>> ExecuteAsync(ListMedicalRecordsCommand command, CancellationToken ct)
    {
        var records = await repository.ListAsync(new MedicalRecordsByPatientSpec(command.PatientId), ct);

        return records
            .Select(r => new MedicalRecordResponse(
                r.Id, r.PatientId, r.DoctorId, r.VisitDate, r.Diagnosis, r.Prescription, r.Notes))
            .ToList();
    }
}