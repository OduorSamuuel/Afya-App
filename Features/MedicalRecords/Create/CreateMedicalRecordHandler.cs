using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.Create;

public sealed class CreateMedicalRecordHandler(IRepository<MedicalRecord> repository)
    : ICommandHandler<CreateMedicalRecordCommand, MedicalRecordResponse>
{
    public async Task<MedicalRecordResponse> ExecuteAsync(CreateMedicalRecordCommand command, CancellationToken ct)
    {
        var record = new MedicalRecord(
            command.PatientId,
            command.DoctorId,
            command.VisitDate,
            command.Diagnosis,
            command.Prescription,
            command.Notes);

        record = await repository.AddAsync(record, ct);

        return new MedicalRecordResponse(
            record.Id, record.PatientId, record.DoctorId, record.VisitDate,
            record.Diagnosis, record.Prescription, record.Notes);
    }
}