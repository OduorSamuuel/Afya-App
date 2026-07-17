using AfyaApp.Domain;
using Ardalis.SharedKernel;
using FastEndpoints;

namespace AfyaApp.Features.MedicalRecords.Update;

public sealed class UpdateMedicalRecordHandler(IRepository<MedicalRecord> repository)
    : ICommandHandler<UpdateMedicalRecordCommand, MedicalRecordResponse?>
{
    public async Task<MedicalRecordResponse?> ExecuteAsync(UpdateMedicalRecordCommand command, CancellationToken ct)
    {
        var record = await repository.GetByIdAsync(command.Id, ct);
        if (record is null) return null;
        
        record.UpdateDetails(command.VisitDate, command.Diagnosis, command.Prescription, command.Notes);
        await repository.UpdateAsync(record, ct);

        return new MedicalRecordResponse(
            record.Id, record.PatientId, record.DoctorId, record.VisitDate,
            record.Diagnosis, record.Prescription, record.Notes);
    }
}