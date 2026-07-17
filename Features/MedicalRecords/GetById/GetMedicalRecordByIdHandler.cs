using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.GetById;

public sealed class GetMedicalRecordByIdHandler(IReadRepository<MedicalRecord> repository)
    : ICommandHandler<GetMedicalRecordByIdCommand, MedicalRecordResponse?>
{
    public async Task<MedicalRecordResponse?> ExecuteAsync(GetMedicalRecordByIdCommand command, CancellationToken ct)
    {
        var record = await repository.GetByIdAsync(command.Id, ct);

        return record is null
            ? null
            : new MedicalRecordResponse(
                record.Id, record.PatientId, record.DoctorId, record.VisitDate,
                record.Diagnosis, record.Prescription, record.Notes);
    }
}